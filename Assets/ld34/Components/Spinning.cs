using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public Vector3 spinRate;

	// Update is called once per frame
	void Update () {
		transform.localEulerAngles += spinRate * Time.deltaTime;
	}
}
