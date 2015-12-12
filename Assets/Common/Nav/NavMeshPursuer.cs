using UnityEngine;
using System.Collections;

namespace FloppyA.Nav {

	public class NavMeshPursuer : MonoBehaviour {
		public Transform target;
		public float targetRepathDistance = 1.0f;
		NavMeshAgent navMeshAgent;
		Vector3 lastDestination;

		void Start () {
			navMeshAgent = GetComponent<NavMeshAgent> ();
		}

		void Update () {
			if (target != null) {
				if (navMeshAgent.destination == null || Vector3.Distance(navMeshAgent.destination, target.position) > targetRepathDistance) {
					if (navMeshAgent.isOnNavMesh) {
						navMeshAgent.SetDestination(target.position);
					}
				}
			}
		}
	}

}
