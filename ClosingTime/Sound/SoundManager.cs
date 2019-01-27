using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosingTime.Sound
{
	public static class SoundManager
	{
		private static IManagesSound instance; 
		public static IManagesSound Instance
		{
			get
			{
				if (instance == null) instance = new IrrKlangSoundManager(); //Default sound manager. 
				return instance; 
			}
		}

		public static void SetSoundManager(IManagesSound mgr)
		{
			instance = mgr; 
		}

		public static void DestroySoundManager()
		{
			instance.StopAllSounds();
			instance = null; 
		}
	}
}
