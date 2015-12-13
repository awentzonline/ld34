using UnityEngine;
using System.Collections;

public class TransformerPowerup : MonoBehaviour {
	public GameObject replacement;

	void OnTriggerEnter(Collider other) {
		Rigidbody otherBody = other.attachedRigidbody;
		if (otherBody != null) {
			if (otherBody.CompareTag ("Player")) {
				GameObject newObj = Instantiate (
					replacement, otherBody.transform.position, otherBody.transform.rotation) as GameObject;
				Rigidbody newBody = newObj.GetComponent<Rigidbody> ();
				newBody.velocity = otherBody.velocity;
				Destroy (gameObject);
				Destroy (otherBody.gameObject);
			}
		}
	}
}
