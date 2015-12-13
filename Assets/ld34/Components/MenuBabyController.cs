using UnityEngine;
using System.Collections;

public class MenuBabyController : MonoBehaviour {
	Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetBool ("Punching", true);
	}

}
