using UnityEngine;
using System.Collections;
using FloppyA.Damage;

public class HealthPowerup : MonoBehaviour {
	public float healthChange = 20f;
	public AudioClip sound;
	
	void OnTriggerEnter(Collider other) {
		Health otherHealth = other.GetComponentInParent<Health> ();
		if (otherHealth) {
			otherHealth.Heal(healthChange);
			if (sound) {
				AudioSource.PlayClipAtPoint(sound, transform.position);
			}
			Destroy (gameObject);
		}
	}
}
