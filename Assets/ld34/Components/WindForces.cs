using UnityEngine;
using System.Collections;

public class WindForces : MonoBehaviour {
	public Vector3 direction;
	public float maxForce = 5f;
	Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		Vector3 force = direction * maxForce;// * Time.fixedDeltaTime;
		rigidbody.AddForce (force);
	}
}
