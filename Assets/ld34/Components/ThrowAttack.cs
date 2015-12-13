using UnityEngine;
using System.Collections;

public class ThrowAttack : MonoBehaviour {
	public GameObject throwThing;
	public float throwVelocity = 5f;
	public Transform throwOrigin;

	public void AttackEvent() {
		GameObject newThing = Instantiate (throwThing, throwOrigin.position, transform.rotation) as GameObject;
		Rigidbody newBody = newThing.GetComponent<Rigidbody> ();
		newBody.velocity = newThing.transform.forward * throwVelocity;
	}
}
