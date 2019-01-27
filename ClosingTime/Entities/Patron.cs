using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;

namespace ClosingTime.Entities
{
	public partial class Patron
	{
		private Vector3 wanderDirection;

		/// <summary>
		/// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
		/// This method is called when the Entity is added to managers. Entities which are instantiated but not
		/// added to managers will not have this method called.
		/// </summary>
		private void CustomInitialize()
		{


		}

		private void CustomActivity()
		{
			

		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

		public void Move(IEnumerable<Player> playerList)
		{
			Vector3 steeringVector = Vector3.Zero;

			foreach(var player in playerList)
			{
				var dist = Vector3.Distance(player.Position, Position);
				if (dist <= MaxReactionDistance)
				{
					steeringVector += GetAvoidVector(player) * dist / MaxReactionDistance;
				}
			}
			steeringVector += GetWanderVector();

			if (steeringVector == Vector3.Zero)
			{
				Velocity = Vector3.Zero; 
			}
			else
			{
				var maxForce = new Vector3(MaxForce, MaxForce, 0);
				var maxSpeed = new Vector3(MaxSpeed, MaxSpeed, 0);
				var steeringForce = Vector3.Min(steeringVector, maxForce);
				steeringForce = Vector3.Max(steeringVector, -maxForce);
				var acceleration = steeringForce / Mass;
				var newVelocity = Velocity + acceleration;
				newVelocity = Vector3.Min(newVelocity, maxSpeed);
				newVelocity = Vector3.Max(newVelocity, -maxSpeed);
				Velocity = newVelocity;
			}
		}

		public Vector3 GetFleeVector(Vector3 target)
		{
			Vector3 desiredVelocity = (Position - target);
			desiredVelocity.Normalize();
			desiredVelocity *= MaxSpeed;
			Vector3 steering = desiredVelocity - Velocity;
			FixSteeringVector(ref steering);
			return desiredVelocity;
		}

		public Vector3 GetWanderVector()
		{
			var wanderRadius = 100;
			var displacementRadius = 20;

			//Start moving if not moving. 
			if (Velocity == Vector3.Zero)
			{
				XVelocity = (float)(FlatRedBallServices.Random.Next(-10, 10));
				YVelocity = (float)(FlatRedBallServices.Random.Next(-10, 10));
			}

			Vector3 displacementVector = new Vector3();
			displacementVector.X = (float)FlatRedBallServices.Random.Next(-101, 100) / 100f;
			displacementVector.Y = (float)FlatRedBallServices.Random.Next(-101, 100) / 100f;
			displacementVector *= (float)FlatRedBallServices.Random.Next(-displacementRadius, displacementRadius);

			wanderDirection = wanderDirection + displacementVector;
			var length = wanderDirection.Length();
			if (length > wanderRadius || length < -wanderRadius)
			{
				wanderDirection.Normalize();
				wanderDirection *= wanderRadius;
			}

			//_easyCircle.Radius = wanderRadius;
			//_easyCircle.Position = _vehicle.Position + (Vector3.Normalize(_vehicle.Velocity) * wanderRadius);
			//_easyAAR.ScaleX = _easyAAR.ScaleY = 10;
			//_easyAAR.Position = _vehicle.Position + (Vector3.Normalize(_vehicle.Velocity) * wanderRadius) + _wanderDirection; 

			var desiredVelocity = (Vector3.Normalize(Velocity) * wanderRadius) + wanderDirection;
			desiredVelocity.Normalize();
			desiredVelocity *= MaxSpeed / 3;
			var steering = desiredVelocity - Velocity;
			FixSteeringVector(ref steering);
			return steering;

		}

		public Vector3 GetAvoidVector(Player player)
		{
			//var estPosition = EstimateFuturePosition(player);
			return GetFleeVector(player.Position);
		}

		public Vector3 EstimateFuturePosition(Player target, Vector3 offset = default(Vector3))
		{
			var distance = Vector3.Distance(Position, target.Position + offset);
			var turningParam = target.Velocity.Length() / target.Mass;
			var T = turningParam * distance;

			var vector = target.Velocity;
			vector.Normalize();
			vector *= T;

			Vector3 estPosition = (target.Position + offset) + (vector);
			return estPosition;
		}


		private void FixSteeringVector(ref Vector3 steering)
		{
			if (float.IsNaN(steering.X)) steering.X = 0;
			if (float.IsNaN(steering.Y)) steering.Y = 0;
			if (float.IsNaN(steering.Z)) steering.Z = 0;
		}
	}
}
