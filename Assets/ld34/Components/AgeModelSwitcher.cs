using UnityEngine;
using System.Collections;
using FloppyA.Music;

public class AgeModelSwitcher : MonoBehaviour {
	public Transform modelHolster;
	public GameObject[] models;
	public GameObject currentObj;
	public AudioClip soundOfAge;
	public AudioClip soundOfYouth;
	public ParticleSystem swapPoofParticles;
	public int numPoofParticles = 30;
	int modelIndex = -1;
	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		UpdateModel (0);
	}

	public void NextOlder() {
		UpdateModel (modelIndex + 1);
		if (audioSource && soundOfAge) {
			audioSource.PlayOneShot(soundOfAge);
		}
		if (swapPoofParticles) {
			swapPoofParticles.Emit (numPoofParticles);
		}
	}

	public void NextYounger() {
		UpdateModel (modelIndex - 1);
		if (audioSource && soundOfYouth) {
			audioSource.PlayOneShot(soundOfYouth);
		}
		if (swapPoofParticles) {
			swapPoofParticles.Emit (numPoofParticles);
		}
	}

	public void UpdateModel(int newIndex) {
		newIndex = Mathf.Clamp (newIndex, 0, models.Length - 1);
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
		// why not cram this in here too?
		ContextualMusicMixer.current.SetIntensity ((MusicContext)modelIndex);
	}
}
