using UnityEngine;
using System.Collections;

using FloppyA.Damage;

public class ThrowAttack : MonoBehaviour {
	public GameObject throwThing;
	public float throwVelocity = 5f;
	public Transform throwOrigin;
	Health healthForBullets;
	public float healthCost = 0f;

	void Start() {
		if (healthCost > 0) {
			healthForBullets = GetComponentInParent<Health>();
		}
	}

	public void AttackEvent() {
		if (healthForBullets) {
			if (healthForBullets.GetHealth () > healthCost) {
				healthForBullets.Damage (healthCost);
			} else {
				return; // no health, no attack
			}
		}
		GameObject newThing = Instantiate (throwThing, throwOrigin.position, transform.rotation) as GameObject;
		Rigidbody newBody = newThing.GetComponent<Rigidbody> ();
		newBody.velocity = newThing.transform.forward * throwVelocity;
	}
}
