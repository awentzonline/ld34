using UnityEngine;
using System.Collections;

public class AgePowerup : MonoBehaviour {
	public float ageChange = 1f;

	void OnTriggerEnter(Collider other) {
		Rigidbody otherBody = other.attachedRigidbody;
		if (otherBody) {
			AgeModelSwitcher ageModel = otherBody.GetComponent<AgeModelSwitcher> ();
			if (ageModel != null) {
				if (ageChange > 0) {
					ageModel.NextOlder();
				} else {
					ageModel.NextYounger();
				}
				Destroy (gameObject);
			}
		}
	}
}
