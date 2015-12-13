using UnityEngine;
using System.Collections;

public class BalloonCapsuleResizer : MonoBehaviour {
	public float minScale = 0.3f;
	public HotAirBalloonController balloonController;
	Vector3 baseScale;

	void Start () {
		//balloonController = GetComponent<HotAirBalloonController> ();
		baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = baseScale * Mathf.Max (minScale, balloonController.inflation);
	}
}
