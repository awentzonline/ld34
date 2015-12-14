using UnityEngine;
using System.Collections;

public class SpawnOverDistance : MonoBehaviour {
	public float minDistance = 2f;
	public GameObject[] spawnables;
	public float spawnProbability = 0.5f;
	Vector3 lastDrop;

	void Start () {
	
	}
	
	void Update () {
		if (lastDrop == null || Vector3.Distance (lastDrop, transform.position) >= minDistance) {
			if (Random.value < spawnProbability) {
				GameObject spawnable = spawnables[Random.Range(0, spawnables.Length - 1)];
				Vector3 position = transform.position;
				position.y = 0f;
				GameObject newObj = Instantiate(spawnable, position, Quaternion.identity) as GameObject;
			}
			lastDrop = transform.position;
		}
	}
}
