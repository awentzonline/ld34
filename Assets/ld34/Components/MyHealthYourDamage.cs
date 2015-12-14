using UnityEngine;
using System.Collections;

using FloppyA.Damage;

public class MyHealthYourDamage : MonoBehaviour {
	Health health;
	public AudioClip impactSound;

	void Start () {
		health = GetComponent<Health> ();
	}

	void OnCollisionEnter(Collision collision) {
		Damageable damageable = collision.collider.GetComponentInParent<Damageable> ();
		if (damageable) {
			DamageInfo damageInfo = new DamageInfo(
				health.GetHealth(), collision.contacts[0].point, collision.contacts[0].normal,
				collision.relativeVelocity.normalized, collision.impulse.magnitude
				);
			damageable.Damage(damageInfo);
			Destroy (gameObject);
			if (impactSound) {
				AudioSource.PlayClipAtPoint(impactSound, collision.contacts[0].point);
			}
		}
	}
}
