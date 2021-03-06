﻿using UnityEngine;
using System.Collections;

public class WaitThenDestroy : MonoBehaviour {
	public float seconds;

	IEnumerator Start () {
		yield return new WaitForSeconds(seconds);
		Destroy (gameObject);
	}

}
