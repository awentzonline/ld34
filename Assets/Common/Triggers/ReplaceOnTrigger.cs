using UnityEngine;
using System.Collections;

namespace FloppyA.Triggers {

	public class ReplaceOnTrigger : MonoBehaviour {
		public GameObject replacementPrefab;
		
		void OnTriggerEnter(Collider other) {
			Instantiate(replacementPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

}
