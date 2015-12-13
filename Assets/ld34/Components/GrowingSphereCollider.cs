using UnityEngine;
using System.Collections;

public class GrowingSphereCollider : MonoBehaviour {
	Collider collider;
	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = transform.localScale +  transform.localScale * 0.1f * Time.deltaTime;
	}
}
