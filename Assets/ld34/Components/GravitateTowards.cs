using UnityEngine;
using System.Collections;

namespace FloppyA.Physics {

	[RequireComponent(typeof(Rigidbody))]
	public class GravitateTowards : MonoBehaviour {
		public Transform centerOfGravity;
		public float gravityForce = 9.8f;
		Rigidbody rigidbody;
	
		void Start () {
			rigidbody = GetComponent<Rigidbody> ();
		}
		
		void Update () {
			if (centerOfGravity != null) {
				Vector3 force = centerOfGravity.position - transform.position;
				force.Normalize();
				force *= gravityForce;
				rigidbody.AddForce(force);
			}
		}
	}

}
