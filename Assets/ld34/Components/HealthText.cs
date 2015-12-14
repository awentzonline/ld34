using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using FloppyA.Damage;

public class HealthText : MonoBehaviour {
	public Health health;
	public Text text;
	public string prefixString = "$";
	float lastHealth = -1f;

	// Update is called once per frame
	void Update () {
		float currentHealth = health.GetHealth ();
		if (currentHealth != lastHealth) {
			text.text = prefixString + currentHealth.ToString();
			lastHealth = currentHealth;
		}
	}
}
