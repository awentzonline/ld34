using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

namespace FloppyA.Damage {

	public class DeathRattle : MonoBehaviour, IOnDiedHandler {
		public AudioClip deathAudioClip;
	
		public void OnDied(DamageInfo damageInfo) {
			AudioSource.PlayClipAtPoint(deathAudioClip, transform.position);
		}
	}

}
