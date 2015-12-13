using UnityEngine;
using System.Collections;

namespace FloppyA.Physics {

	[RequireComponent(typeof(Cloth))]
	public class ClothGravitateTowards : MonoBehaviour {
		public Transform centerOfGravity;
		public float gravityForce = 9.8f;
		Cloth cloth;
	
		void Start () {
			cloth = GetComponent<Cloth> ();
		}
		
		void Update () {
			if (centerOfGravity != null) {
				Vector3 force = centerOfGravity.position - transform.position;
				force.Normalize();
				force *= gravityForce;
				cloth.externalAcceleration = force;
			}
		}
	}

}
