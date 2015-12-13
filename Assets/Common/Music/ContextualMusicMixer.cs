using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

namespace FloppyA.Music {

	public enum MusicContext {
		BabyContext, KidContext, AdultContext, ElderlyContext
	}

	[System.Serializable]
	public class MusicContextConfig {
		public MusicContext musicContext;
		public AudioMixerSnapshot snapshot;
		public float transitionTime = 0.3f;
	}

	public class ContextualMusicMixer : MonoBehaviour {
		static public ContextualMusicMixer current;
		public MusicContextConfig[] contextConfigs;
		public MusicContext defaultContext;
		Dictionary<MusicContext, MusicContextConfig> configMap;
		MusicContextConfig currentContext;

		void Awake() {
			current = this;
		}

		void Start() {
			configMap = new Dictionary<MusicContext, MusicContextConfig> ();
			foreach (MusicContextConfig config in contextConfigs) {
				configMap[config.musicContext] = config;
			}
			SetIntensity (defaultContext);
		}

		public void SetIntensity(MusicContext newContext) {
			if ((int)newContext >= configMap.Count) {
				return;
			}
			MusicContextConfig config = configMap [newContext];
			if (config != null) {
				config.snapshot.TransitionTo(config.transitionTime);
			}
			currentContext = config;
		}
	}

}
