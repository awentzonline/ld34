using UnityEngine;
using System.Collections;

public class Ageing : MonoBehaviour {
	public float age;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncrementAge(float amount) {
		age += amount;
	}
}
