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
	public partial class Player
	{
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

		internal void MoveToward(Vector3 position)
		{
			var maxForce = new Vector3(MaxForce, MaxForce, 0);
			var maxSpeed = new Vector3(MaxSpeed, MaxSpeed, 0); 
			var arrivalVector = GetArrivalVector(position);
			var steeringForce = Vector3.Min(arrivalVector, maxForce);
			steeringForce = Vector3.Max(steeringForce, -maxForce);
			var acceleration = steeringForce / Mass;
			var newVelocity = Velocity + acceleration;
			newVelocity = Vector3.Min(newVelocity, maxSpeed);
			newVelocity = Vector3.Max(newVelocity, -maxSpeed);
			Velocity = newVelocity; 
		}

		public Vector3 GetArrivalVector(Vector3 target)
		{
			Vector3 targetOffset = (target - Position);
			var distance = targetOffset.Length();
			var rampingSpeed = MaxSpeed * (distance / DistanceToArrive);
			var clippingSpeed = Math.Min(rampingSpeed, MaxSpeed);
			var desiredVelocity = (clippingSpeed / distance) * targetOffset;
			Vector3 steering = desiredVelocity - Velocity;
			FixSteeringVector(ref steering);
			return steering;
		}

		private void FixSteeringVector(ref Vector3 steering)
		{
			if (float.IsNaN(steering.X)) steering.X = 0;
			if (float.IsNaN(steering.Y)) steering.Y = 0;
			if (float.IsNaN(steering.Z)) steering.Z = 0;
		}
	}
}
