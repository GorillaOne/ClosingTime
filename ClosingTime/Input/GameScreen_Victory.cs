using ClosingTime.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosingTime.Input
{
	public class GameScreen_Victory : IUserInteractionState
	{
		private readonly GameScreen gameScreen;

		public GameScreen_Victory(GameScreen gameScreen)
		{
			this.gameScreen = gameScreen;
		}

		public void Setup()
		{
			gameScreen.GameScreenGumRuntime.VictoryOverlayInstance.ToMenuButtonClick += VictoryOverlayInstance_ToMenuButtonClick;
		}



		public void Activity()
		{
			throw new NotImplementedException();
		}

		public void Teardown()
		{
			gameScreen.GameScreenGumRuntime.VictoryOverlayInstance.ToMenuButtonClick -= VictoryOverlayInstance_ToMenuButtonClick;
		}

		private void VictoryOverlayInstance_ToMenuButtonClick(FlatRedBall.Gui.IWindow window)
		{
			gameScreen.MoveToScreen(typeof(MenuScreen)); 
		}
	}
}
