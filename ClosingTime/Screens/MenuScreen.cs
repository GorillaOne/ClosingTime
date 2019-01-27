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
using ClosingTime.Input;
using ClosingTime.Sound;

namespace ClosingTime.Screens
{
	public partial class MenuScreen : IManagesUserInteraction
	{

		IUserInteractionState currentState; 

		void CustomInitialize()
		{
			CreateLevelSelectButtons(); 
		}

		void CustomActivity(bool firstTimeCalled)
		{
			currentState?.Activity(); 
		}

		void CustomDestroy()
		{
			MenuScreenGumRuntime.LevelSelectInstance.ClearRuntimes();
		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

		public void LoadUserInteractionState(IUserInteractionState state)
		{
			currentState?.Teardown();
			currentState = state;
			currentState.Setup(); 
		}

		private void CreateLevelSelectButtons()
		{
			foreach (var world in GlobalContent.Levels.Keys)
			{
				//MainMenuScreenGumRuntime.LevelSelectInstance.AddTitle(world);
				for (int i = 0; i < GlobalContent.Levels[world].LevelName.Count; i++)
				{
					var levelName = GlobalContent.Levels[world].LevelName[i];
					var screenName = GlobalContent.Levels[world].ScreenName[i];
					var button = MenuScreenGumRuntime.LevelSelectInstance.AddButton(levelName);
					button.Click += (sender, args) => { MoveToScreen(screenName); };
				}
			}
		}
	}
}
