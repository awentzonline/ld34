using UnityEngine;
using System.Collections;
using FloppyA.Damage;

public class MoneyHazard : MonoBehaviour {
	public float forceMagnitude = 0f;
	public float amount = 10f;
	public AudioClip soundFx; 

	void OnTriggerEnter(Collider other) {
		Damageable otherDamageable = other.GetComponentInParent<Damageable> ();
		if (otherDamageable) {
			DamageInfo damageInfo = new DamageInfo(amount, transform.position, transform.up, transform.up, forceMagnitude);
			otherDamageable.Damage(damageInfo);
			if (soundFx) {
				AudioSource.PlayClipAtPoint(soundFx, transform.position);
			}
		}
	}
}
