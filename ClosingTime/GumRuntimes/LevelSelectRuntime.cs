using FlatRedBall.Forms.Controls;
using System.Collections.Generic;

namespace ClosingTime.GumRuntimes
{
	public partial class LevelSelectRuntime
	{
		private List<Button> buttonList = new List<Button>();

		partial void CustomInitialize()
		{
		}

		public Button AddButton(string text)
		{
			var button = new Button();
			button.Visual.AddToManagers();
			button.Text = text;
			button.Visual.Parent = LevelsContainer;
			button.Visual.AddToManagers();
			buttonList.Add(button);
			return button;
		}

		public void ClearRuntimes()
		{
			foreach (var button in buttonList)
			{
				button.Visual.RemoveFromManagers();
			}
			buttonList.Clear();
			LevelsContainer.Children.Clear();
		}
	}
}
