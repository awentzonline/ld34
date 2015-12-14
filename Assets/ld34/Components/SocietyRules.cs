using UnityEngine;
using System.Collections;

public class SocietyRules : MonoBehaviour {
	static public SocietyRules current;
	public Transform loseObject;

	void Awake () {
		current = this;
	}

	public void Lose () {
		// show lose message
		StartCoroutine ("DoLose");
	}

	public IEnumerator DoLose () {
		// show lose message
		if (loseObject) {
			loseObject.gameObject.SetActive(true);
		}
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("Menu");
	}
}
