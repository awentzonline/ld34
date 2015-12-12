using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FloppyA.Spawn {

	public class SpawnArea : MonoBehaviour {
		public GameObject[] prefabs;
		public float spawnRate = 1.0f;  // per second
		float spawnCountdown = 0.0f;

		void Update () {
			spawnCountdown -= Time.deltaTime;
			if (spawnCountdown <= 0) {
				DoSpawn();
				spawnCountdown = 1f / spawnRate;
			}
		}

		void DoSpawn() {
			// get a random prefab
			GameObject prefab = prefabs [Random.Range (0, prefabs.Length)];
			// position it randomly in the spawn, facing forward
			Vector3 position = new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f));
			position = transform.TransformPoint (position);
			Quaternion rotation = Quaternion.LookRotation (transform.TransformDirection (Vector3.forward));
			GameObject newObj = Instantiate(prefab, position, rotation) as GameObject;
			// do more things to the spawned object
			foreach (ISpawnHandler handler in GetComponents<ISpawnHandler> ()) {
				handler.OnSpawn(newObj);
			}
		}
	}

}
