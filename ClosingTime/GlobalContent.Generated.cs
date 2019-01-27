#if ANDROID || IOS || DESKTOP_GL
// Android doesn't allow background loading. iOS doesn't allow background rendering (which is used by converting textures to use premult alpha)
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using System.Collections.Generic;
using System.Threading;
using FlatRedBall;
using FlatRedBall.Math.Geometry;
using FlatRedBall.ManagedSpriteGroups;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using FlatRedBall.Localization;
using ClosingTime.DataTypes;
using FlatRedBall.IO.Csv;

namespace ClosingTime
{
    public static partial class GlobalContent
    {
        
        public static System.Collections.Generic.Dictionary<string, ClosingTime.DataTypes.Levels> Levels { get; set; }
        public static FlatRedBall.Gum.GumIdb GumProject { get; set; }
        public static System.Collections.Generic.List<ClosingTime.DataTypes.SoundFiles> SoundFiles { get; set; }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Levels":
                    return Levels;
                case  "GumProject":
                    return GumProject;
                case  "SoundFiles":
                    return SoundFiles;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "Levels":
                    return Levels;
                case  "GumProject":
                    return GumProject;
                case  "SoundFiles":
                    return SoundFiles;
            }
            return null;
        }
        public static bool IsInitialized { get; private set; }
        public static bool ShouldStopLoading { get; set; }
        const string ContentManagerName = "Global";
        public static void Initialize () 
        {
            
            if (Levels == null)
            {
                {
                    // We put the { and } to limit the scope of oldDelimiter
                    char oldDelimiter = FlatRedBall.IO.Csv.CsvFileManager.Delimiter;
                    FlatRedBall.IO.Csv.CsvFileManager.Delimiter = ',';
                    System.Collections.Generic.Dictionary<string, ClosingTime.DataTypes.Levels> temporaryCsvObject = new System.Collections.Generic.Dictionary<string, ClosingTime.DataTypes.Levels>();
                    FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeDictionary<string, ClosingTime.DataTypes.Levels>("content/globalcontent/levels.csv", temporaryCsvObject);
                    FlatRedBall.IO.Csv.CsvFileManager.Delimiter = oldDelimiter;
                    Levels = temporaryCsvObject;
                }
            }
            FlatRedBall.Gum.GumIdb.StaticInitialize("content/gumproject/gumproject.gumx"); FlatRedBall.Gum.GumIdbExtensions.RegisterTypes();  FlatRedBall.Gui.GuiManager.BringsClickedWindowsToFront = false;FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += (not, used) => { FlatRedBall.Gum.GumIdb.UpdateDisplayToMainFrbCamera(); };Gum.Wireframe.GraphicalUiElement.ShowLineRectangles = false;
            if (SoundFiles == null)
            {
                {
                    // We put the { and } to limit the scope of oldDelimiter
                    char oldDelimiter = FlatRedBall.IO.Csv.CsvFileManager.Delimiter;
                    FlatRedBall.IO.Csv.CsvFileManager.Delimiter = ',';
                    System.Collections.Generic.List<ClosingTime.DataTypes.SoundFiles> temporaryCsvObject = new System.Collections.Generic.List<ClosingTime.DataTypes.SoundFiles>();
                    FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeList(typeof(ClosingTime.DataTypes.SoundFiles), "content/globalcontent/soundfiles.csv", temporaryCsvObject);
                    FlatRedBall.IO.Csv.CsvFileManager.Delimiter = oldDelimiter;
                    SoundFiles = temporaryCsvObject;
                }
            }
            			IsInitialized = true;
            // Added by GumPlugin becasue of the Show Mouse checkbox on the .gumx:
            FlatRedBall.FlatRedBallServices.Game.IsMouseVisible = true;
            #if DEBUG && WINDOWS
            InitializeFileWatch();
            #endif
        }
        public static void Reload (object whatToReload) 
        {
            if (whatToReload == Levels)
            {
                FlatRedBall.IO.Csv.CsvFileManager.UpdateDictionaryValuesFromCsv(Levels, "content/globalcontent/levels.csv");
            }
            if (whatToReload == SoundFiles)
            {
                {
                    // We put the { and } to limit the scope of oldDelimiter
                    char oldDelimiter = FlatRedBall.IO.Csv.CsvFileManager.Delimiter;
                    FlatRedBall.IO.Csv.CsvFileManager.Delimiter = ',';
                    SoundFiles.Clear();
                    FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeList(typeof(ClosingTime.DataTypes.SoundFiles), "content/globalcontent/soundfiles.csv", SoundFiles);
                    FlatRedBall.IO.Csv.CsvFileManager.Delimiter = oldDelimiter;
                }
            }
        }
        #if DEBUG && WINDOWS
        static System.IO.FileSystemWatcher watcher;
        private static void InitializeFileWatch () 
        {
            string globalContent = FlatRedBall.IO.FileManager.RelativeDirectory + "content/globalcontent/";
            if (System.IO.Directory.Exists(globalContent))
            {
                watcher = new System.IO.FileSystemWatcher();
                watcher.Path = globalContent;
                watcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
                watcher.Filter = "*.*";
                watcher.Changed += HandleFileChanged;
                watcher.EnableRaisingEvents = true;
            }
        }
        private static void HandleFileChanged (object sender, System.IO.FileSystemEventArgs e) 
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                var fullFileName = e.FullPath;
                var relativeFileName = FlatRedBall.IO.FileManager.MakeRelative(FlatRedBall.IO.FileManager.Standardize(fullFileName));
                if (relativeFileName == "content/gumproject/gumproject.gumx")
                {
                    Reload(GumProject);
                }
            }
            catch{}
        }
        #endif
        
        
    }
}
