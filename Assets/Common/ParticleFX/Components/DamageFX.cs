using UnityEngine;
using System.Collections;
using FloppyA.Damage;

namespace FloppyA.ParticleFX {

	[RequireComponent(typeof(Damageable))]
	public class DamageFX : MonoBehaviour, IOnDamageHandler {
		public FXType fxType = FXType.SmokePuff;
		public float damageAmountRatio = 1.0f;
		Health health;

		void Start() {
			health = GetComponent<Health> ();
		}

		public void OnDamage(DamageInfo damageInfo) {
			float relativeDamage = damageAmountRatio;
			if (health != null) {
				relativeDamage = damageInfo.amount / health.maxHealth;
			}
			WorldParticleFX.current.MakeFX (fxType, damageInfo.point, damageInfo.normal, relativeDamage);
		}
	}

}