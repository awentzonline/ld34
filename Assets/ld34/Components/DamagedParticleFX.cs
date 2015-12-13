using UnityEngine;
using System.Collections;
using FloppyA.Damage;

[RequireComponent(typeof(Damageable))]
public class DamagedParticleFX : MonoBehaviour, IOnDamageHandler {
	public ParticleSystem particleSystem;
	public float damageAmountRatio = 1.0f;
	public int maxParticles = 30;
	public bool considerHealth = true;
	Health health;
	
	void Start() {
		health = GetComponent<Health> ();
	}
	
	public void OnDamage(DamageInfo damageInfo) {
		float relativeDamage = damageAmountRatio;
		if (health != null && considerHealth) {
			relativeDamage = damageInfo.amount / health.maxHealth;
		}
		particleSystem.Emit((int) (relativeDamage * maxParticles));
	}
}
