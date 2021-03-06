#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
namespace ClosingTime.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static FlatRedBall.TileGraphics.LayeredTileMap Level1Map;
        protected static FlatRedBall.Gum.GumIdb GameScreenGum;
        
        protected FlatRedBall.TileGraphics.LayeredTileMap MapInstance;
        private FlatRedBall.Math.Geometry.ShapeCollection WorldCollision;
        protected FlatRedBall.Camera CameraInstance;
        private FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.Patron> mPatronList;
        public FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.Patron> PatronList
        {
            get
            {
                return mPatronList;
            }
            private set
            {
                mPatronList = value;
            }
        }
        private FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.Player> mPlayerList;
        public FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.Player> PlayerList
        {
            get
            {
                return mPlayerList;
            }
            private set
            {
                mPlayerList = value;
            }
        }
        private FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.DoorExit> DoorExitList;
        private FlatRedBall.Math.Geometry.ShapeCollection BarArea;
        private ClosingTime.GumRuntimes.GameScreenGumRuntime mGameScreenGumRuntime;
        public ClosingTime.GumRuntimes.GameScreenGumRuntime GameScreenGumRuntime
        {
            get
            {
                return mGameScreenGumRuntime;
            }
            private set
            {
                mGameScreenGumRuntime = value;
            }
        }
        private FlatRedBall.Graphics.Layer GUILayer;
        private FlatRedBall.Graphics.Layer GameLayer;
        public virtual string MapName { get; set; }
        protected global::RenderingLibrary.Graphics.Layer GUILayerGum;
        protected global::RenderingLibrary.Graphics.Layer GameLayerGum;
        public GameScreen () 
        	: base ("GameScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            // Not instantiating for LayeredTileMap MapInstance in Screens\GameScreen (Screen) because properties on the object prevent it
            WorldCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            WorldCollision.Name = "WorldCollision";
            CameraInstance = FlatRedBall.SpriteManager.Camera;
            mPatronList = new FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.Patron>();
            mPatronList.Name = "mPatronList";
            mPlayerList = new FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.Player>();
            mPlayerList.Name = "mPlayerList";
            DoorExitList = new FlatRedBall.Math.PositionedObjectList<ClosingTime.Entities.DoorExit>();
            DoorExitList.Name = "DoorExitList";
            BarArea = new FlatRedBall.Math.Geometry.ShapeCollection();
            BarArea.Name = "BarArea";
            mGameScreenGumRuntime = GameScreenGum.GetGraphicalUiElementByName("this") as ClosingTime.GumRuntimes.GameScreenGumRuntime;
            GUILayer = new FlatRedBall.Graphics.Layer();
            GUILayer.Name = "GUILayer";
            GameLayer = new FlatRedBall.Graphics.Layer();
            GameLayer.Name = "GameLayer";
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            Level1Map.AddToManagers(mLayer);
            GameScreenGum.InstanceInitialize(); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += GameScreenGum.HandleResolutionChanged;
            FlatRedBall.SpriteManager.AddLayer(GUILayer);
            GUILayer.UsePixelCoordinates();
            if (FlatRedBall.SpriteManager.Camera.Orthogonal)
            {
                GUILayer.LayerCameraSettings.OrthogonalWidth = FlatRedBall.SpriteManager.Camera.OrthogonalWidth;
                GUILayer.LayerCameraSettings.OrthogonalHeight = FlatRedBall.SpriteManager.Camera.OrthogonalHeight;
            }
            FlatRedBall.SpriteManager.AddLayer(GameLayer);
            GameLayer.UsePixelCoordinates();
            if (FlatRedBall.SpriteManager.Camera.Orthogonal)
            {
                GameLayer.LayerCameraSettings.OrthogonalWidth = FlatRedBall.SpriteManager.Camera.OrthogonalWidth;
                GameLayer.LayerCameraSettings.OrthogonalHeight = FlatRedBall.SpriteManager.Camera.OrthogonalHeight;
            }
            GUILayerGum = RenderingLibrary.SystemManagers.Default.Renderer.AddLayer();
            GUILayerGum.Name = "GUILayerGum";
            GameScreenGum.AddGumLayerToFrbLayer(GUILayerGum, GUILayer);
            GameLayerGum = RenderingLibrary.SystemManagers.Default.Renderer.AddLayer();
            GameLayerGum.Name = "GameLayerGum";
            GameScreenGum.AddGumLayerToFrbLayer(GameLayerGum, GameLayer);
            Factories.PatronFactory.Initialize(ContentManagerName);
            Factories.PlayerFactory.Initialize(ContentManagerName);
            Factories.DoorExitFactory.Initialize(ContentManagerName);
            Factories.PatronFactory.AddList(mPatronList);
            Factories.PlayerFactory.AddList(mPlayerList);
            Factories.DoorExitFactory.AddList(DoorExitList);
            WorldCollision.AddToManagers(GameLayer);
            BarArea.AddToManagers();
            mGameScreenGumRuntime.AddToManagers(RenderingLibrary.SystemManagers.Default, System.Linq.Enumerable.FirstOrDefault(FlatRedBall.Gum.GumIdb.AllGumLayersOnFrbLayer(GUILayer)));

            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                if (MapInstance != null)
                {
                }
                for (int i = PatronList.Count - 1; i > -1; i--)
                {
                    if (i < PatronList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        PatronList[i].Activity();
                    }
                }
                for (int i = PlayerList.Count - 1; i > -1; i--)
                {
                    if (i < PlayerList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        PlayerList[i].Activity();
                    }
                }
                for (int i = DoorExitList.Count - 1; i > -1; i--)
                {
                    if (i < DoorExitList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        DoorExitList[i].Activity();
                    }
                }
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
            Factories.PatronFactory.Destroy();
            Factories.PlayerFactory.Destroy();
            Factories.DoorExitFactory.Destroy();
            Level1Map.Destroy();
            Level1Map = null;
            FlatRedBall.SpriteManager.RemoveDrawableBatch(GameScreenGum); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= GameScreenGum.HandleResolutionChanged;
            GameScreenGum = null;
            
            PatronList.MakeOneWay();
            PlayerList.MakeOneWay();
            DoorExitList.MakeOneWay();
            if (WorldCollision != null)
            {
                WorldCollision.RemoveFromManagers(ContentManagerName != "Global");
            }
            for (int i = PatronList.Count - 1; i > -1; i--)
            {
                PatronList[i].Destroy();
            }
            for (int i = PlayerList.Count - 1; i > -1; i--)
            {
                PlayerList[i].Destroy();
            }
            for (int i = DoorExitList.Count - 1; i > -1; i--)
            {
                DoorExitList[i].Destroy();
            }
            if (BarArea != null)
            {
                BarArea.RemoveFromManagers(ContentManagerName != "Global");
            }
            if (GameScreenGumRuntime != null)
            {
                GameScreenGumRuntime.RemoveFromManagers();
            }
            if (GUILayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(GUILayer);
            }
            if (GameLayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(GameLayer);
            }
            PatronList.MakeTwoWay();
            PlayerList.MakeTwoWay();
            DoorExitList.MakeTwoWay();
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
            mGameScreenGumRuntime.MoveToFrbLayer(GUILayer, GUILayerGum);
            FlatRedBall.Gui.GuiManager.SortZAndLayerBased();
        }
        public virtual void RemoveFromManagers () 
        {
            if (WorldCollision != null)
            {
                WorldCollision.RemoveFromManagers(false);
            }
            for (int i = PatronList.Count - 1; i > -1; i--)
            {
                PatronList[i].Destroy();
            }
            for (int i = PlayerList.Count - 1; i > -1; i--)
            {
                PlayerList[i].Destroy();
            }
            for (int i = DoorExitList.Count - 1; i > -1; i--)
            {
                DoorExitList[i].Destroy();
            }
            if (BarArea != null)
            {
                BarArea.RemoveFromManagers(false);
            }
            if (GameScreenGumRuntime != null)
            {
                GameScreenGumRuntime.RemoveFromManagers();
            }
            if (GUILayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(GUILayer);
            }
            if (GameLayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(GameLayer);
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
            for (int i = 0; i < PatronList.Count; i++)
            {
                PatronList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < PlayerList.Count; i++)
            {
                PlayerList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < DoorExitList.Count; i++)
            {
                DoorExitList[i].ConvertToManuallyUpdated();
            }
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
            Level1Map = FlatRedBall.TileGraphics.LayeredTileMap.FromTiledMapSave("content/screens/gamescreen/levels/level1map.tmx", contentManagerName);
            Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = true;  GameScreenGum = new FlatRedBall.Gum.GumIdb();  GameScreenGum.LoadFromFile("content/gumproject/screens/gamescreengum.gusx");  GameScreenGum.AssignReferences();Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = false; GameScreenGum.Element.UpdateLayout(); GameScreenGum.Element.UpdateLayout();
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
                case  "Level1Map":
                    return Level1Map;
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "Level1Map":
                    return Level1Map;
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Level1Map":
                    return Level1Map;
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
    }
}
