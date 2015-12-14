using UnityEngine;
using System.Collections;

public class DestroyOnEnter : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		Rigidbody rigidbody = collider.attachedRigidbody;
		if (rigidbody) {
		}
	}
}
