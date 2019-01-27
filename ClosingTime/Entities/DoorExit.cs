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
	public partial class DoorExit
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

		public void SetPolygon(Polygon polygon)
		{
			Collision.Polygons[0].Points = polygon.Points;
			this.Position = polygon.Position;

			SetExitSign(); 
		}

		public void SetExitSign()
		{
			float num = 0;
			Vector3 position = Vector3.Zero;
			foreach (var point in Collision.Polygons[0].Points)
			{
				num++;
				position += point.ToVector3();
			}
			position /= num;
			TextInstance.RelativePosition = position;
		}
	}
}
