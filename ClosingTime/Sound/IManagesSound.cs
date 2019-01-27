using Microsoft.Xna.Framework;

namespace ClosingTime.Sound
{
	public enum EffectType
    {
        Music,
		SFX,
    }
    public interface IManagesSound
    {
        float MinSoundDistance { get; set; }
        float MaxSoundDistance { get; set; }
		bool PlayingMusic { get; }
		void Activity(); 
        void PlaySFX(string fileName);
        void PlayMusic(string fileName);
        void StopAllSounds();
    }
}
