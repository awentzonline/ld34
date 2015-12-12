using UnityEngine;
using System.Collections;

namespace FloppyA.Damage {

	public class ReplaceOnDied : MonoBehaviour, IOnDiedHandler {
		public GameObject replacementPrefab;
		public bool deepCopyTransform = false;

		public void OnDied(DamageInfo damageInfo) {
			GameObject replacement = Instantiate(replacementPrefab, transform.position, transform.rotation) as GameObject;
			if (deepCopyTransform) {
				CopyTransformsRecurse(transform, replacement.transform);
			}
			// Maybe handle this by deferring force application for a frame elsewhere
			Rigidbody thisBody = GetComponentInChildren<Rigidbody> ();
			Rigidbody[] replacementBodies = replacement.GetComponentsInChildren<Rigidbody> ();
			if (thisBody != null && replacementBodies.Length > 0) {
				foreach (Rigidbody replacementBody in replacementBodies) {
					replacementBody.velocity = thisBody.velocity;
					//replacementBody.AddForceAtPosition (damageInfo.forceMagnitude * damageInfo.direction / replacementBodies.Length, damageInfo.point, ForceMode.Impulse);
				}
			}
			Destroy (gameObject);
		}

		static void CopyTransformsRecurse (Transform src, Transform dst) {
			dst.position = src.position;
			dst.rotation = src.rotation;
			dst.gameObject.SetActive(true);
			
			foreach (Transform child in dst) {
				// Match the transform with the same name
				var curSrc = src.Find(child.name);
				if (curSrc)
					CopyTransformsRecurse(curSrc,  child);
			}
		}
	}

}
