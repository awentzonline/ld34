using UnityEngine;
using System.Collections;

namespace FloppyA.Physics {

	[RequireComponent(typeof(Cloth))]
	public class ClothBlobController : MonoBehaviour {
		Cloth cloth;

		void Start () {
			cloth = GetComponent<Cloth> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}

}
