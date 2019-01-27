    namespace FlatRedBall.Gum
    {
        public  class GumIdbExtensions
        {
            public static void RegisterTypes () 
            {
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Circle", typeof(ClosingTime.GumRuntimes.CircleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ColoredRectangle", typeof(ClosingTime.GumRuntimes.ColoredRectangleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container", typeof(ClosingTime.GumRuntimes.ContainerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("NineSlice", typeof(ClosingTime.GumRuntimes.NineSliceRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Polygon", typeof(ClosingTime.GumRuntimes.PolygonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Rectangle", typeof(ClosingTime.GumRuntimes.RectangleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Sprite", typeof(ClosingTime.GumRuntimes.SpriteRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Text", typeof(ClosingTime.GumRuntimes.TextRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Button", typeof(ClosingTime.GumRuntimes.DefaultForms.ButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/CheckBox", typeof(ClosingTime.GumRuntimes.DefaultForms.CheckBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ColoredFrame", typeof(ClosingTime.GumRuntimes.DefaultForms.ColoredFrameRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ComboBox", typeof(ClosingTime.GumRuntimes.DefaultForms.ComboBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ListBox", typeof(ClosingTime.GumRuntimes.DefaultForms.ListBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ListBoxItem", typeof(ClosingTime.GumRuntimes.DefaultForms.ListBoxItemRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/PasswordBox", typeof(ClosingTime.GumRuntimes.DefaultForms.PasswordBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/RadioButton", typeof(ClosingTime.GumRuntimes.DefaultForms.RadioButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ScrollBar", typeof(ClosingTime.GumRuntimes.DefaultForms.ScrollBarRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ScrollBarThumb", typeof(ClosingTime.GumRuntimes.DefaultForms.ScrollBarThumbRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ScrollViewer", typeof(ClosingTime.GumRuntimes.DefaultForms.ScrollViewerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/Slider", typeof(ClosingTime.GumRuntimes.DefaultForms.SliderRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TextBox", typeof(ClosingTime.GumRuntimes.DefaultForms.TextBoxRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/ToggleButton", typeof(ClosingTime.GumRuntimes.DefaultForms.ToggleButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TreeView", typeof(ClosingTime.GumRuntimes.DefaultForms.TreeViewRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TreeViewItem", typeof(ClosingTime.GumRuntimes.DefaultForms.TreeViewItemRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/TreeViewToggleButton", typeof(ClosingTime.GumRuntimes.DefaultForms.TreeViewToggleButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("DefaultForms/UserControl", typeof(ClosingTime.GumRuntimes.DefaultForms.UserControlRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("LevelSelect", typeof(ClosingTime.GumRuntimes.LevelSelectRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Timer", typeof(ClosingTime.GumRuntimes.TimerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("VictoryOverlay", typeof(ClosingTime.GumRuntimes.VictoryOverlayRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("WordBubble", typeof(ClosingTime.GumRuntimes.WordBubbleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("GameScreenGum", typeof(ClosingTime.GumRuntimes.GameScreenGumRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("MenuScreenGum", typeof(ClosingTime.GumRuntimes.MenuScreenGumRuntime));
                
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Button)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ButtonRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.CheckBox)] = typeof(ClosingTime.GumRuntimes.DefaultForms.CheckBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ComboBox)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ComboBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ListBox)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ListBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ListBoxItem)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ListBoxItemRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.PasswordBox)] = typeof(ClosingTime.GumRuntimes.DefaultForms.PasswordBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.RadioButton)] = typeof(ClosingTime.GumRuntimes.DefaultForms.RadioButtonRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ScrollBar)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ScrollBarRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ScrollViewer)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ScrollViewerRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.Slider)] = typeof(ClosingTime.GumRuntimes.DefaultForms.SliderRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TextBox)] = typeof(ClosingTime.GumRuntimes.DefaultForms.TextBoxRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.ToggleButton)] = typeof(ClosingTime.GumRuntimes.DefaultForms.ToggleButtonRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TreeView)] = typeof(ClosingTime.GumRuntimes.DefaultForms.TreeViewRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.TreeViewItem)] = typeof(ClosingTime.GumRuntimes.DefaultForms.TreeViewItemRuntime);
                FlatRedBall.Forms.Controls.FrameworkElement.DefaultFormsComponents[typeof(FlatRedBall.Forms.Controls.UserControl)] = typeof(ClosingTime.GumRuntimes.DefaultForms.UserControlRuntime);
            }
        }
    }
