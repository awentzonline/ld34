using UnityEngine;
using System.Collections;

using FloppyA.Nav;

namespace FloppyA.Spawn {

	public class OnSpawnPursueTaggedObject : MonoBehaviour, ISpawnHandler {
		public string targetTag = "Player";
	
		public void OnSpawn(GameObject newObj) {
			NavMeshPursuer pursuer = newObj.GetComponent<NavMeshPursuer> ();
			if (pursuer != null) {
				GameObject targetObj = GameObject.FindGameObjectWithTag(targetTag);
				if (targetObj != null) {
					pursuer.target = targetObj.transform;
				}
			}
		}
	}

}
