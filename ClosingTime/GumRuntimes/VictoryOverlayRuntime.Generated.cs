    using System.Linq;
    namespace ClosingTime.GumRuntimes
    {
        public partial class VictoryOverlayRuntime : ClosingTime.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            #endregion
            #region State Properties
            public VariableState CurrentVariableState
            {
                get
                {
                    return mCurrentVariableState;
                }
                set
                {
                    mCurrentVariableState = value;
                    switch(mCurrentVariableState)
                    {
                        case  VariableState.Default:
                            Height = 100f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Width = 100f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Background.Alpha = 255;
                            Background.Blue = 0;
                            Background.Green = 0;
                            Background.Height = 100f;
                            Background.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Background.Red = 0;
                            Background.Width = 100f;
                            Background.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Title.Font = "Calibri";
                            Title.FontSize = 46;
                            Title.Height = 20f;
                            Title.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Title.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            Title.Text = "Closing Time";
                            Title.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            Title.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            Title.Y = 30f;
                            ClosingTitle.FontSize = 32;
                            ClosingTitle.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ClosingTitle.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Title") ?? this;
                            ClosingTitle.Text = "Closing took you:";
                            ClosingTitle.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ClosingTitle.Width = 30f;
                            ClosingTitle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            ClosingTitle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ClosingTitle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ClosingTitle.Y = 100f;
                            ClosingTitle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            ClosingTitle.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            TimeDisplay.FontSize = 32;
                            TimeDisplay.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            TimeDisplay.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ClosingTitle") ?? this;
                            TimeDisplay.Text = "10.25 Seconds";
                            TimeDisplay.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            TimeDisplay.Width = 367f;
                            TimeDisplay.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            TimeDisplay.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            TimeDisplay.Y = 25f;
                            TimeDisplay.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            TimeDisplay.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ToMenuButton.Height = 50f;
                            ToMenuButton.Text = "Back To Menu";
                            ToMenuButton.Width = 200f;
                            ToMenuButton.X = -10f;
                            ToMenuButton.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            ToMenuButton.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            ToMenuButton.Y = -10f;
                            ToMenuButton.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            ToMenuButton.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            break;
                    }
                }
            }
            #endregion
            #region State Interpolation
            public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setBackgroundAlphaFirstValue = false;
                bool setBackgroundAlphaSecondValue = false;
                int BackgroundAlphaFirstValue= 0;
                int BackgroundAlphaSecondValue= 0;
                bool setBackgroundBlueFirstValue = false;
                bool setBackgroundBlueSecondValue = false;
                int BackgroundBlueFirstValue= 0;
                int BackgroundBlueSecondValue= 0;
                bool setBackgroundGreenFirstValue = false;
                bool setBackgroundGreenSecondValue = false;
                int BackgroundGreenFirstValue= 0;
                int BackgroundGreenSecondValue= 0;
                bool setBackgroundHeightFirstValue = false;
                bool setBackgroundHeightSecondValue = false;
                float BackgroundHeightFirstValue= 0;
                float BackgroundHeightSecondValue= 0;
                bool setBackgroundRedFirstValue = false;
                bool setBackgroundRedSecondValue = false;
                int BackgroundRedFirstValue= 0;
                int BackgroundRedSecondValue= 0;
                bool setBackgroundWidthFirstValue = false;
                bool setBackgroundWidthSecondValue = false;
                float BackgroundWidthFirstValue= 0;
                float BackgroundWidthSecondValue= 0;
                bool setClosingTitleFontSizeFirstValue = false;
                bool setClosingTitleFontSizeSecondValue = false;
                int ClosingTitleFontSizeFirstValue= 0;
                int ClosingTitleFontSizeSecondValue= 0;
                bool setClosingTitleWidthFirstValue = false;
                bool setClosingTitleWidthSecondValue = false;
                float ClosingTitleWidthFirstValue= 0;
                float ClosingTitleWidthSecondValue= 0;
                bool setClosingTitleYFirstValue = false;
                bool setClosingTitleYSecondValue = false;
                float ClosingTitleYFirstValue= 0;
                float ClosingTitleYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setTimeDisplayFontSizeFirstValue = false;
                bool setTimeDisplayFontSizeSecondValue = false;
                int TimeDisplayFontSizeFirstValue= 0;
                int TimeDisplayFontSizeSecondValue= 0;
                bool setTimeDisplayWidthFirstValue = false;
                bool setTimeDisplayWidthSecondValue = false;
                float TimeDisplayWidthFirstValue= 0;
                float TimeDisplayWidthSecondValue= 0;
                bool setTimeDisplayYFirstValue = false;
                bool setTimeDisplayYSecondValue = false;
                float TimeDisplayYFirstValue= 0;
                float TimeDisplayYSecondValue= 0;
                bool setTitleFontSizeFirstValue = false;
                bool setTitleFontSizeSecondValue = false;
                int TitleFontSizeFirstValue= 0;
                int TitleFontSizeSecondValue= 0;
                bool setTitleHeightFirstValue = false;
                bool setTitleHeightSecondValue = false;
                float TitleHeightFirstValue= 0;
                float TitleHeightSecondValue= 0;
                bool setTitleYFirstValue = false;
                bool setTitleYSecondValue = false;
                float TitleYFirstValue= 0;
                float TitleYSecondValue= 0;
                bool setToMenuButtonHeightFirstValue = false;
                bool setToMenuButtonHeightSecondValue = false;
                float ToMenuButtonHeightFirstValue= 0;
                float ToMenuButtonHeightSecondValue= 0;
                bool setToMenuButtonWidthFirstValue = false;
                bool setToMenuButtonWidthSecondValue = false;
                float ToMenuButtonWidthFirstValue= 0;
                float ToMenuButtonWidthSecondValue= 0;
                bool setToMenuButtonXFirstValue = false;
                bool setToMenuButtonXSecondValue = false;
                float ToMenuButtonXFirstValue= 0;
                float ToMenuButtonXSecondValue= 0;
                bool setToMenuButtonYFirstValue = false;
                bool setToMenuButtonYSecondValue = false;
                float ToMenuButtonYFirstValue= 0;
                float ToMenuButtonYSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setBackgroundAlphaFirstValue = true;
                        BackgroundAlphaFirstValue = 255;
                        setBackgroundBlueFirstValue = true;
                        BackgroundBlueFirstValue = 0;
                        setBackgroundGreenFirstValue = true;
                        BackgroundGreenFirstValue = 0;
                        setBackgroundHeightFirstValue = true;
                        BackgroundHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.Background.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundRedFirstValue = true;
                        BackgroundRedFirstValue = 0;
                        setBackgroundWidthFirstValue = true;
                        BackgroundWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.Background.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setClosingTitleFontSizeFirstValue = true;
                        ClosingTitleFontSizeFirstValue = 32;
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Title") ?? this;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.Text = "Closing took you:";
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        setClosingTitleWidthFirstValue = true;
                        ClosingTitleWidthFirstValue = 30f;
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setClosingTitleYFirstValue = true;
                        ClosingTitleYFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClosingTitle.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTimeDisplayFontSizeFirstValue = true;
                        TimeDisplayFontSizeFirstValue = 32;
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ClosingTitle") ?? this;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.Text = "10.25 Seconds";
                        }
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        setTimeDisplayWidthFirstValue = true;
                        TimeDisplayWidthFirstValue = 367f;
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setTimeDisplayYFirstValue = true;
                        TimeDisplayYFirstValue = 25f;
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TimeDisplay.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Title.Font = "Calibri";
                        }
                        setTitleFontSizeFirstValue = true;
                        TitleFontSizeFirstValue = 46;
                        setTitleHeightFirstValue = true;
                        TitleHeightFirstValue = 20f;
                        if (interpolationValue < 1)
                        {
                            this.Title.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Title.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Title.Text = "Closing Time";
                        }
                        if (interpolationValue < 1)
                        {
                            this.Title.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Title.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTitleYFirstValue = true;
                        TitleYFirstValue = 30f;
                        setToMenuButtonHeightFirstValue = true;
                        ToMenuButtonHeightFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.ToMenuButton.Text = "Back To Menu";
                        }
                        setToMenuButtonWidthFirstValue = true;
                        ToMenuButtonWidthFirstValue = 200f;
                        setToMenuButtonXFirstValue = true;
                        ToMenuButtonXFirstValue = -10f;
                        if (interpolationValue < 1)
                        {
                            this.ToMenuButton.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ToMenuButton.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setToMenuButtonYFirstValue = true;
                        ToMenuButtonYFirstValue = -10f;
                        if (interpolationValue < 1)
                        {
                            this.ToMenuButton.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ToMenuButton.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setBackgroundAlphaSecondValue = true;
                        BackgroundAlphaSecondValue = 255;
                        setBackgroundBlueSecondValue = true;
                        BackgroundBlueSecondValue = 0;
                        setBackgroundGreenSecondValue = true;
                        BackgroundGreenSecondValue = 0;
                        setBackgroundHeightSecondValue = true;
                        BackgroundHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setBackgroundRedSecondValue = true;
                        BackgroundRedSecondValue = 0;
                        setBackgroundWidthSecondValue = true;
                        BackgroundWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setClosingTitleFontSizeSecondValue = true;
                        ClosingTitleFontSizeSecondValue = 32;
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Title") ?? this;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.Text = "Closing took you:";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        setClosingTitleWidthSecondValue = true;
                        ClosingTitleWidthSecondValue = 30f;
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setClosingTitleYSecondValue = true;
                        ClosingTitleYSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClosingTitle.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTimeDisplayFontSizeSecondValue = true;
                        TimeDisplayFontSizeSecondValue = 32;
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ClosingTitle") ?? this;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.Text = "10.25 Seconds";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        setTimeDisplayWidthSecondValue = true;
                        TimeDisplayWidthSecondValue = 367f;
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setTimeDisplayYSecondValue = true;
                        TimeDisplayYSecondValue = 25f;
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TimeDisplay.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Title.Font = "Calibri";
                        }
                        setTitleFontSizeSecondValue = true;
                        TitleFontSizeSecondValue = 46;
                        setTitleHeightSecondValue = true;
                        TitleHeightSecondValue = 20f;
                        if (interpolationValue >= 1)
                        {
                            this.Title.HeightUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Title.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Title.Text = "Closing Time";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Title.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Title.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setTitleYSecondValue = true;
                        TitleYSecondValue = 30f;
                        setToMenuButtonHeightSecondValue = true;
                        ToMenuButtonHeightSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.ToMenuButton.Text = "Back To Menu";
                        }
                        setToMenuButtonWidthSecondValue = true;
                        ToMenuButtonWidthSecondValue = 200f;
                        setToMenuButtonXSecondValue = true;
                        ToMenuButtonXSecondValue = -10f;
                        if (interpolationValue >= 1)
                        {
                            this.ToMenuButton.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ToMenuButton.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setToMenuButtonYSecondValue = true;
                        ToMenuButtonYSecondValue = -10f;
                        if (interpolationValue >= 1)
                        {
                            this.ToMenuButton.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ToMenuButton.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        break;
                }
                if (setBackgroundAlphaFirstValue && setBackgroundAlphaSecondValue)
                {
                    Background.Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundAlphaFirstValue* (1 - interpolationValue) + BackgroundAlphaSecondValue * interpolationValue);
                }
                if (setBackgroundBlueFirstValue && setBackgroundBlueSecondValue)
                {
                    Background.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundBlueFirstValue* (1 - interpolationValue) + BackgroundBlueSecondValue * interpolationValue);
                }
                if (setBackgroundGreenFirstValue && setBackgroundGreenSecondValue)
                {
                    Background.Green = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundGreenFirstValue* (1 - interpolationValue) + BackgroundGreenSecondValue * interpolationValue);
                }
                if (setBackgroundHeightFirstValue && setBackgroundHeightSecondValue)
                {
                    Background.Height = BackgroundHeightFirstValue * (1 - interpolationValue) + BackgroundHeightSecondValue * interpolationValue;
                }
                if (setBackgroundRedFirstValue && setBackgroundRedSecondValue)
                {
                    Background.Red = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundRedFirstValue* (1 - interpolationValue) + BackgroundRedSecondValue * interpolationValue);
                }
                if (setBackgroundWidthFirstValue && setBackgroundWidthSecondValue)
                {
                    Background.Width = BackgroundWidthFirstValue * (1 - interpolationValue) + BackgroundWidthSecondValue * interpolationValue;
                }
                if (setClosingTitleFontSizeFirstValue && setClosingTitleFontSizeSecondValue)
                {
                    ClosingTitle.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(ClosingTitleFontSizeFirstValue* (1 - interpolationValue) + ClosingTitleFontSizeSecondValue * interpolationValue);
                }
                if (setClosingTitleWidthFirstValue && setClosingTitleWidthSecondValue)
                {
                    ClosingTitle.Width = ClosingTitleWidthFirstValue * (1 - interpolationValue) + ClosingTitleWidthSecondValue * interpolationValue;
                }
                if (setClosingTitleYFirstValue && setClosingTitleYSecondValue)
                {
                    ClosingTitle.Y = ClosingTitleYFirstValue * (1 - interpolationValue) + ClosingTitleYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setTimeDisplayFontSizeFirstValue && setTimeDisplayFontSizeSecondValue)
                {
                    TimeDisplay.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(TimeDisplayFontSizeFirstValue* (1 - interpolationValue) + TimeDisplayFontSizeSecondValue * interpolationValue);
                }
                if (setTimeDisplayWidthFirstValue && setTimeDisplayWidthSecondValue)
                {
                    TimeDisplay.Width = TimeDisplayWidthFirstValue * (1 - interpolationValue) + TimeDisplayWidthSecondValue * interpolationValue;
                }
                if (setTimeDisplayYFirstValue && setTimeDisplayYSecondValue)
                {
                    TimeDisplay.Y = TimeDisplayYFirstValue * (1 - interpolationValue) + TimeDisplayYSecondValue * interpolationValue;
                }
                if (setTitleFontSizeFirstValue && setTitleFontSizeSecondValue)
                {
                    Title.FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(TitleFontSizeFirstValue* (1 - interpolationValue) + TitleFontSizeSecondValue * interpolationValue);
                }
                if (setTitleHeightFirstValue && setTitleHeightSecondValue)
                {
                    Title.Height = TitleHeightFirstValue * (1 - interpolationValue) + TitleHeightSecondValue * interpolationValue;
                }
                if (setTitleYFirstValue && setTitleYSecondValue)
                {
                    Title.Y = TitleYFirstValue * (1 - interpolationValue) + TitleYSecondValue * interpolationValue;
                }
                if (setToMenuButtonHeightFirstValue && setToMenuButtonHeightSecondValue)
                {
                    ToMenuButton.Height = ToMenuButtonHeightFirstValue * (1 - interpolationValue) + ToMenuButtonHeightSecondValue * interpolationValue;
                }
                if (setToMenuButtonWidthFirstValue && setToMenuButtonWidthSecondValue)
                {
                    ToMenuButton.Width = ToMenuButtonWidthFirstValue * (1 - interpolationValue) + ToMenuButtonWidthSecondValue * interpolationValue;
                }
                if (setToMenuButtonXFirstValue && setToMenuButtonXSecondValue)
                {
                    ToMenuButton.X = ToMenuButtonXFirstValue * (1 - interpolationValue) + ToMenuButtonXSecondValue * interpolationValue;
                }
                if (setToMenuButtonYFirstValue && setToMenuButtonYSecondValue)
                {
                    ToMenuButton.Y = ToMenuButtonYFirstValue * (1 - interpolationValue) + ToMenuButtonYSecondValue * interpolationValue;
                }
                if (setWidthFirstValue && setWidthSecondValue)
                {
                    Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
                }
                if (interpolationValue < 1)
                {
                    mCurrentVariableState = firstState;
                }
                else
                {
                    mCurrentVariableState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (ClosingTime.GumRuntimes.VictoryOverlayRuntime.VariableState fromState,ClosingTime.GumRuntimes.VictoryOverlayRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
            {
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from:0, to:1, duration:(float)secondsToTake, type:interpolationType, easing:easing );
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(fromState, toState, newPosition);
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.States.First(item => item.Name == toState.ToString());
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = AddToCurrentValuesWithState(toState);
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            #endregion
            #region State Animations
            #endregion
            public override void StopAnimations () 
            {
                base.StopAnimations();
                ToMenuButton.StopAnimations();
            }
            #region Get Current Values on State
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height Units",
                            Type = "DimensionUnitType",
                            Value = HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width Units",
                            Type = "DimensionUnitType",
                            Value = WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Alpha",
                            Type = "int",
                            Value = Background.Alpha
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Blue",
                            Type = "int",
                            Value = Background.Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Green",
                            Type = "int",
                            Value = Background.Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height",
                            Type = "float",
                            Value = Background.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height Units",
                            Type = "DimensionUnitType",
                            Value = Background.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Red",
                            Type = "int",
                            Value = Background.Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width",
                            Type = "float",
                            Value = Background.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width Units",
                            Type = "DimensionUnitType",
                            Value = Background.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Font",
                            Type = "string",
                            Value = Title.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.FontSize",
                            Type = "int",
                            Value = Title.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Height",
                            Type = "float",
                            Value = Title.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Height Units",
                            Type = "DimensionUnitType",
                            Value = Title.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = Title.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Text",
                            Type = "string",
                            Value = Title.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = Title.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Width Units",
                            Type = "DimensionUnitType",
                            Value = Title.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Y",
                            Type = "float",
                            Value = Title.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.FontSize",
                            Type = "int",
                            Value = ClosingTitle.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = ClosingTitle.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Parent",
                            Type = "string",
                            Value = ClosingTitle.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Text",
                            Type = "string",
                            Value = ClosingTitle.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = ClosingTitle.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Width",
                            Type = "float",
                            Value = ClosingTitle.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Width Units",
                            Type = "DimensionUnitType",
                            Value = ClosingTitle.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ClosingTitle.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.X Units",
                            Type = "PositionUnitType",
                            Value = ClosingTitle.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Y",
                            Type = "float",
                            Value = ClosingTitle.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ClosingTitle.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Y Units",
                            Type = "PositionUnitType",
                            Value = ClosingTitle.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.FontSize",
                            Type = "int",
                            Value = TimeDisplay.FontSize
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = TimeDisplay.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Parent",
                            Type = "string",
                            Value = TimeDisplay.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Text",
                            Type = "string",
                            Value = TimeDisplay.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = TimeDisplay.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Width",
                            Type = "float",
                            Value = TimeDisplay.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.X Origin",
                            Type = "HorizontalAlignment",
                            Value = TimeDisplay.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.X Units",
                            Type = "PositionUnitType",
                            Value = TimeDisplay.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Y",
                            Type = "float",
                            Value = TimeDisplay.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Y Origin",
                            Type = "VerticalAlignment",
                            Value = TimeDisplay.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Y Units",
                            Type = "PositionUnitType",
                            Value = TimeDisplay.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Height",
                            Type = "float",
                            Value = ToMenuButton.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Text",
                            Type = "string",
                            Value = ToMenuButton.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Width",
                            Type = "float",
                            Value = ToMenuButton.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.X",
                            Type = "float",
                            Value = ToMenuButton.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ToMenuButton.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.X Units",
                            Type = "PositionUnitType",
                            Value = ToMenuButton.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Y",
                            Type = "float",
                            Value = ToMenuButton.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ToMenuButton.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Y Units",
                            Type = "PositionUnitType",
                            Value = ToMenuButton.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height Units",
                            Type = "DimensionUnitType",
                            Value = HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width Units",
                            Type = "DimensionUnitType",
                            Value = WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Alpha",
                            Type = "int",
                            Value = Background.Alpha + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Blue",
                            Type = "int",
                            Value = Background.Blue + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Green",
                            Type = "int",
                            Value = Background.Green + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height",
                            Type = "float",
                            Value = Background.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height Units",
                            Type = "DimensionUnitType",
                            Value = Background.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Red",
                            Type = "int",
                            Value = Background.Red + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width",
                            Type = "float",
                            Value = Background.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width Units",
                            Type = "DimensionUnitType",
                            Value = Background.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Font",
                            Type = "string",
                            Value = Title.Font
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.FontSize",
                            Type = "int",
                            Value = Title.FontSize + 46
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Height",
                            Type = "float",
                            Value = Title.Height + 20f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Height Units",
                            Type = "DimensionUnitType",
                            Value = Title.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = Title.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Text",
                            Type = "string",
                            Value = Title.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = Title.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Width Units",
                            Type = "DimensionUnitType",
                            Value = Title.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Title.Y",
                            Type = "float",
                            Value = Title.Y + 30f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.FontSize",
                            Type = "int",
                            Value = ClosingTitle.FontSize + 32
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = ClosingTitle.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Parent",
                            Type = "string",
                            Value = ClosingTitle.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Text",
                            Type = "string",
                            Value = ClosingTitle.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = ClosingTitle.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Width",
                            Type = "float",
                            Value = ClosingTitle.Width + 30f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Width Units",
                            Type = "DimensionUnitType",
                            Value = ClosingTitle.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ClosingTitle.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.X Units",
                            Type = "PositionUnitType",
                            Value = ClosingTitle.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Y",
                            Type = "float",
                            Value = ClosingTitle.Y + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ClosingTitle.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ClosingTitle.Y Units",
                            Type = "PositionUnitType",
                            Value = ClosingTitle.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.FontSize",
                            Type = "int",
                            Value = TimeDisplay.FontSize + 32
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = TimeDisplay.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Parent",
                            Type = "string",
                            Value = TimeDisplay.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Text",
                            Type = "string",
                            Value = TimeDisplay.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = TimeDisplay.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Width",
                            Type = "float",
                            Value = TimeDisplay.Width + 367f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.X Origin",
                            Type = "HorizontalAlignment",
                            Value = TimeDisplay.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.X Units",
                            Type = "PositionUnitType",
                            Value = TimeDisplay.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Y",
                            Type = "float",
                            Value = TimeDisplay.Y + 25f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Y Origin",
                            Type = "VerticalAlignment",
                            Value = TimeDisplay.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TimeDisplay.Y Units",
                            Type = "PositionUnitType",
                            Value = TimeDisplay.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Height",
                            Type = "float",
                            Value = ToMenuButton.Height + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Text",
                            Type = "string",
                            Value = ToMenuButton.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Width",
                            Type = "float",
                            Value = ToMenuButton.Width + 200f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.X",
                            Type = "float",
                            Value = ToMenuButton.X + -10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ToMenuButton.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.X Units",
                            Type = "PositionUnitType",
                            Value = ToMenuButton.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Y",
                            Type = "float",
                            Value = ToMenuButton.Y + -10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ToMenuButton.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ToMenuButton.Y Units",
                            Type = "PositionUnitType",
                            Value = ToMenuButton.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            #endregion
            public override void ApplyState (Gum.DataTypes.Variables.StateSave state) 
            {
                bool matches = this.ElementSave.AllStates.Contains(state);
                if (matches)
                {
                    var category = this.ElementSave.Categories.FirstOrDefault(item => item.States.Contains(state));
                    if (category == null)
                    {
                        if (state.Name == "Default") this.mCurrentVariableState = VariableState.Default;
                    }
                }
                base.ApplyState(state);
            }
            private ClosingTime.GumRuntimes.ColoredRectangleRuntime Background { get; set; }
            private ClosingTime.GumRuntimes.TextRuntime Title { get; set; }
            private ClosingTime.GumRuntimes.TextRuntime ClosingTitle { get; set; }
            private ClosingTime.GumRuntimes.TextRuntime TimeDisplay { get; set; }
            private ClosingTime.GumRuntimes.DefaultForms.ButtonRuntime ToMenuButton { get; set; }
            public string TimeDisplayText
            {
                get
                {
                    return TimeDisplay.Text;
                }
                set
                {
                    if (TimeDisplay.Text != value)
                    {
                        TimeDisplay.Text = value;
                        TimeDisplayTextChanged?.Invoke(this, null);
                    }
                }
            }
            public event FlatRedBall.Gui.WindowEvent ToMenuButtonClick;
            public event System.EventHandler TimeDisplayTextChanged;
            public VictoryOverlayRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "VictoryOverlay");
                    this.ElementSave = elementSave;
                    string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                    FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                    GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                    FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
                }
            }
            public override void SetInitialState () 
            {
                base.SetInitialState();
                this.CurrentVariableState = VariableState.Default;
                CallCustomInitialize();
            }
            public override void CreateChildrenRecursively (Gum.DataTypes.ElementSave elementSave, RenderingLibrary.SystemManagers systemManagers) 
            {
                base.CreateChildrenRecursively(elementSave, systemManagers);
                this.AssignReferences();
            }
            private void AssignReferences () 
            {
                Background = this.GetGraphicalUiElementByName("Background") as ClosingTime.GumRuntimes.ColoredRectangleRuntime;
                Title = this.GetGraphicalUiElementByName("Title") as ClosingTime.GumRuntimes.TextRuntime;
                ClosingTitle = this.GetGraphicalUiElementByName("ClosingTitle") as ClosingTime.GumRuntimes.TextRuntime;
                TimeDisplay = this.GetGraphicalUiElementByName("TimeDisplay") as ClosingTime.GumRuntimes.TextRuntime;
                ToMenuButton = this.GetGraphicalUiElementByName("ToMenuButton") as ClosingTime.GumRuntimes.DefaultForms.ButtonRuntime;
                ToMenuButton.Click += (unused) => ToMenuButtonClick?.Invoke(this);
            }
            public override void AddToManagers (RenderingLibrary.SystemManagers managers, RenderingLibrary.Graphics.Layer layer) 
            {
                base.AddToManagers(managers, layer);
            }
            private void CallCustomInitialize () 
            {
                CustomInitialize();
            }
            partial void CustomInitialize();
        }
    }
