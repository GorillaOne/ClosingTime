using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IrrKlang;
using Microsoft.Xna.Framework.Media;
using FlatRedBall.IO;
using FlatRedBall;
using Microsoft.Xna.Framework;
using FlatRedBall.Debugging;
using System.Reflection;

namespace ClosingTime.Sound
{
	public class IrrKlangSoundManager : IManagesSound
	{
        const float defaultMinSoundDistance = 500;
        const float defaultMaxSoundDistance = 600; 

        public float MinSoundDistance { get; set; }
        public float MaxSoundDistance { get; set; }
		public bool PlayingMusic { get; private set; }

        ISoundEngine mSoundEngine = new ISoundEngine();

		Dictionary<string, ISoundSource> soundSources = new Dictionary<string, ISoundSource>(); 

        public IrrKlangSoundManager()
        {
            Initialize();             
        }

        private void Initialize()
        {
			soundSources = LoadSoundSources();  
		}

		[STAThread]
		private void LoadSource(string fileName, string nickname, EffectType effectType, float volume, float minSoundVolume)
		{
			var source = mSoundEngine.AddSoundSourceFromFile(fileName);
			source = mSoundEngine.AddSoundSourceAlias(source, nickname);

			source.DefaultVolume = volume;
			source.DefaultMinDistance = minSoundVolume;

			var fieldInfo = this.GetType().GetField(effectType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
			List<string> list = (List<string>)fieldInfo.GetValue(this);

			if (!String.IsNullOrEmpty(nickname))
			{
				list.Add(nickname);
			}
			else
			{
				list.Add(fileName);
			}
		}

		public void Activity()
        {
            PositionListener();
        }

        private void PositionListener()
        {
            Vector3D listenerPosition = new Vector3D(Camera.Main.X, Camera.Main.Y, -100);
            Vector3D lookdirection = new Vector3D(0, 0, 1);
            Vector3D velPerSecond = new Vector3D(0, 0, 0);
            Vector3D upVector = new Vector3D(0, 1, 0);

            mSoundEngine.SetListenerPosition(listenerPosition, lookdirection, velPerSecond, upVector); 
        }

		[STAThread]
        public void PlaySFX(string identifier)
        {
			var source = soundSources[identifier];
			mSoundEngine.Play2D(source, false, false, false);
        }

        [STAThread]
        public void PlayMusic(string identifier)
        {
			var source = soundSources[identifier];
			mSoundEngine.Play2D(source, true, false, false);
			PlayingMusic = true;
		}

        [STAThread]
        public void StopAllSounds()
        {			
            mSoundEngine.StopAllSounds();
			PlayingMusic = false; 
        }

        private List<string> GetEffectList(EffectType effectType)
        {
            var fieldInfo = this.GetType().GetField(effectType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            return (List<string>)fieldInfo.GetValue(this); 
        }

		[STAThread]
		private Dictionary<string, ISoundSource> LoadSoundSources()
		{
			Dictionary<string, ISoundSource> sources = new Dictionary<string, ISoundSource>(); 
			foreach (var entry in GlobalContent.SoundFiles)
			{
				var source = mSoundEngine.AddSoundSourceFromFile(entry.FilePath);
				source = mSoundEngine.AddSoundSourceAlias(source, entry.Identifier);
				source.DefaultVolume = entry.Volume;
				sources.Add(source.Name, source); 
			}

			return sources; 
		}
	}

	public enum SoundType
	{
		SFX,
		Music
	}
}
