using ClosingTime.Screens;
using FlatRedBall.Gui;
using FlatRedBall.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosingTime.Input
{
	public class GameScreen_Default : IUserInteractionState
	{
		private readonly GameScreen gameScreen;
		IPressableInput moveButton = InputManager.Mouse.GetButton(Mouse.MouseButtons.LeftButton);
		Vector3 lastMouseDown; 

		public GameScreen_Default(GameScreen gameScreen)
		{
			this.gameScreen = gameScreen;
		}

		public void Setup()
		{
			
		}

		public void Activity()
		{
			if (moveButton.IsDown)
			{
				lastMouseDown = new Vector3(GuiManager.Cursor.WorldXAt(0), GuiManager.Cursor.WorldYAt(0), 0);
				gameScreen.MovePlayersToward(lastMouseDown);
			}
			else if (lastMouseDown != Vector3.Zero)
			{
				gameScreen.MovePlayersToward(lastMouseDown);
			}
		}

		public void Teardown()
		{
			
		}
	}
}
