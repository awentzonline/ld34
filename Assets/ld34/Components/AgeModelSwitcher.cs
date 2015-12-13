using UnityEngine;
using System.Collections;

public class AgeModelSwitcher : MonoBehaviour {
	public Transform modelHolster;
	public GameObject[] models;
	public GameObject currentObj;
	public int modelIndex = -1;

	void Start() {
		UpdateModel (0);
	}

	public void NextOlder() {
		UpdateModel (modelIndex + 1);
	}

	public void NextYounger() {
		UpdateModel (modelIndex - 1);
	}

	public void UpdateModel(int newIndex) {
		newIndex = Mathf.Clamp (newIndex, 0, models.Length);
		if (newIndex == modelIndex) {
			return;
		}
		GameObject model = models [newIndex];
		GameObject newObj;
		newObj = Instantiate(
			model, modelHolster.transform.position, modelHolster.transform.rotation) as GameObject;
		newObj.transform.parent = modelHolster;
		if (currentObj != null) {
			Destroy (currentObj);
		}
		currentObj = newObj;
		modelIndex = newIndex;
	}
}
