#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace ClosingTime.Screens
{
    public partial class MenuScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static FlatRedBall.Gum.GumIdb MenuScreenGum;
        
        private ClosingTime.GumRuntimes.MenuScreenGumRuntime MenuScreenGumRuntime;
        public MenuScreen () 
        	: base ("MenuScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            MenuScreenGumRuntime = MenuScreenGum.GetGraphicalUiElementByName("this") as ClosingTime.GumRuntimes.MenuScreenGumRuntime;
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            MenuScreenGum.InstanceInitialize(); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += MenuScreenGum.HandleResolutionChanged;
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            FlatRedBall.SpriteManager.RemoveDrawableBatch(MenuScreenGum); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= MenuScreenGum.HandleResolutionChanged;
            MenuScreenGum = null;
            
            if (MenuScreenGumRuntime != null)
            {
                MenuScreenGumRuntime.RemoveFromManagers();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            if (MenuScreenGumRuntime != null)
            {
                MenuScreenGumRuntime.RemoveFromManagers();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            // Set the content manager for Gum
            var contentManagerWrapper = new FlatRedBall.Gum.ContentManagerWrapper();
            contentManagerWrapper.ContentManagerName = contentManagerName;
            RenderingLibrary.Content.LoaderManager.Self.ContentLoader = contentManagerWrapper;
            // Access the GumProject just in case it's async loaded
            var throwaway = GlobalContent.GumProject;
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = true;  MenuScreenGum = new FlatRedBall.Gum.GumIdb();  MenuScreenGum.LoadFromFile("content/gumproject/screens/menuscreengum.gusx");  MenuScreenGum.AssignReferences();Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = false; MenuScreenGum.Element.UpdateLayout(); MenuScreenGum.Element.UpdateLayout();
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "MenuScreenGum":
                    return MenuScreenGum;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "MenuScreenGum":
                    return MenuScreenGum;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "MenuScreenGum":
                    return MenuScreenGum;
            }
            return null;
        }
    }
}
