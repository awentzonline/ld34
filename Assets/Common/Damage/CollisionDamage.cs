using UnityEngine;
using System.Collections;

namespace FloppyA.Damage {

	[RequireComponent(typeof(Damageable))]
	public class CollisionDamage : MonoBehaviour {
		public float minDamagingForce = 30f;
		public float maxDamagingForce = 100f;
		public float forceDamage = 200.0f;
		Damageable damageable;

		void Start() {
			damageable = GetComponent<Damageable> ();
		}

		void OnCollisionEnter(Collision collision) {
			float force = collision.impulse.magnitude / Time.fixedDeltaTime;
			Rigidbody otherBody = collision.rigidbody;
			if (force > minDamagingForce) {
				float ratio = (force - minDamagingForce) / (maxDamagingForce - minDamagingForce);
				ratio = Mathf.Max (0f, Mathf.Min (1f, ratio));
				ContactPoint cp = collision.contacts[0];
				DamageInfo damageInfo = new DamageInfo(
					forceDamage * ratio, cp.point, cp.normal,
					collision.relativeVelocity.normalized, force);
				damageable.Damage(damageInfo);
			}
		}
	}

}
