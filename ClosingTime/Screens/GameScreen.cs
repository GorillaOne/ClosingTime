using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using FlatRedBall.TileGraphics;
using FlatRedBall.TileEntities;
using ClosingTime.Input;
using Microsoft.Xna.Framework;
using FlatRedBall.Math.Collision;
using ClosingTime.Entities;
using FlatRedBall.Debugging;
using ClosingTime.Factories;
using ClosingTime.Sound;
using System.Timers;

namespace ClosingTime.Screens
{
	public partial class GameScreen : IManagesUserInteraction
	{

		IUserInteractionState currentState;
		private Dictionary<string, Polygon> cachedDoorExits = new Dictionary<string, Polygon>();
		int patronsInBar;
		bool firstRun = false;
		bool victory = false; 

		void CustomInitialize()
		{
			StartSound();
			SetGumStates();
			LoadTMX();
			PositionCamera();
			SetupCollisionRelationships();
			LoadUserInteractionState(new GameScreen_Default(this));
		}


		void CustomActivity(bool firstTimeCalled)
		{
			if (!victory)
			{
				var time = Math.Round(this.PauseAdjustedCurrentTime, 2);
				GameScreenGumRuntime.TimerInstance.TimeDisplayText = time.ToString("F");
				currentState?.Activity();
				foreach (var patron in PatronList)
				{
					patron.Move(PlayerList);
				}
				foreach (var aar in WorldCollision.AxisAlignedRectangles)
				{
					aar.ForceUpdateDependenciesDeep();
				}

				if (!firstRun) firstRun = true;
				else
				{
					CheckForVictory();
					patronsInBar = 0;
				}
			}

		}


		void CustomDestroy()
		{
			SoundManager.Instance.StopAllSounds(); 

		}

		static void CustomLoadStaticContent(string contentManagerName)
		{


		}

		private void SetGumStates()
		{
			GameScreenGumRuntime.CurrentVictoryDisplayState = GumRuntimes.GameScreenGumRuntime.VictoryDisplay.Off;
		}

		private void StartSound()
		{
			SoundManager.Instance.PlaySFX("getoutofhere");

			Timer timer = new Timer(2000);
			timer.Elapsed += (a, b) => {
				SoundManager.Instance.PlayMusic("rockitout");
				timer.Stop();
			};
			timer.Start();
		}

		private void LoadTMX()
		{
			MapInstance = (LayeredTileMap)GetFile(MapName);
			MapInstance.AddToManagers();
			WorldCollision.AddToThis(MapInstance.ShapeCollections.Find((a) => a.Name == "WorldCollision"));
			WorldCollision.Visible = true;
			BarArea.AddToThis(MapInstance.ShapeCollections.Find((a) => a.Name == "BarArea"));
			BarArea.Visible = false; 
			CacheDoorSizes();
			TileEntityInstantiator.CreateEntitiesFrom(MapInstance);
			SetDoorSizes(); 
			SetWorldZ();
		}

		protected void SetWorldZ()
		{
			foreach (var circle in WorldCollision.Circles)
			{
				circle.Z = 0;
			}
			foreach (var polygon in WorldCollision.Polygons)
			{
				polygon.Z = 0;
			}
			foreach (var rect in WorldCollision.AxisAlignedRectangles)
			{
				rect.Z = 0;
			}
			foreach(var player in PlayerList)
			{
				player.Z = 0; 
			}
			foreach(var patron in PatronList)
			{
				patron.Z = 0; 
			}
		}

		private void PositionCamera()
		{
			var offset = new Vector3(MapInstance.Width / 2, MapInstance.Height / 2, 0);
			CameraInstance.Position = new Vector3(offset.X, -offset.Y, CameraInstance.Z);
		}

		private void CacheDoorSizes()
		{
			foreach (var shape in MapInstance.ShapeCollections.Find((a) => a.Name == "Entities").Polygons)
			{
				cachedDoorExits.Add(shape.Name, shape);
			}
		}

		private void SetDoorSizes()
		{ 
			foreach (var door in DoorExitList)
			{
				door.SetPolygon(cachedDoorExits[door.Name]);
			}
		}

		private void SetupCollisionRelationships()
		{
			var playerPatron = CollisionManager.Self.CreateRelationship(PlayerList, PatronList);
			playerPatron.SetBounceCollision(1, 1, 0);

			var patronWorld = CollisionManager.Self.CreateRelationship(PatronList, WorldCollision);
			patronWorld.SetBounceCollision(0, 1, 0); 

			var playerWorld = CollisionManager.Self.CreateRelationship(PlayerList, WorldCollision);
			playerWorld.SetMoveCollision(0, 1);

			var patronBar = CollisionManager.Self.CreateRelationship(PatronList, BarArea);
			patronBar.CollisionOccurred += (a,b) => { patronsInBar++;  }; 
		}

		public void LoadUserInteractionState(IUserInteractionState state)
		{
			currentState?.Teardown();
			currentState = state;
			currentState.Setup();
		}

		private void CheckForVictory()
		{
			if (patronsInBar == 0)
			{
				victory = true;
				GameScreenGumRuntime.CurrentVictoryDisplayState = GumRuntimes.GameScreenGumRuntime.VictoryDisplay.On;
				GameScreenGumRuntime.VictoryOverlayInstance.TimeDisplayText = $"{GameScreenGumRuntime.TimerInstance.TimeDisplayText} seconds";
				LoadUserInteractionState(new GameScreen_Victory(this)); 
			}
		}


		public void MovePlayersToward(Vector3 position)
		{
			foreach(var player in PlayerList)
			{
				player.MoveToward(position);
			}
		}
	}
}
