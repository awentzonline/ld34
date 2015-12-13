using UnityEngine;
using System.Collections;

public class HotAirBalloonController : MonoBehaviour {
	Rigidbody rigidbody;
	public float inflation = 0.0f;
	public float lossRate = 0.1f;
	public float ventRate = 0.3f;
	public float maxForceGravityRatio = 1.5f;
	public float inflateRate = 0.2f;
	public float inflateHeatRate = 0.4f;
	public float heat = 0f;
	public float cooldownRate = 0.3f;
	public bool wantsToInflate = false;
	public bool isVenting = false;
	float maxBuoyantForce;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		maxBuoyantForce = Physics.gravity.magnitude * maxForceGravityRatio;
	}
	
	void FixedUpdate () {
		// TODO: make this better
		float thisLossRate = lossRate;
		if (isVenting) {
			thisLossRate += ventRate;
		}

		inflation = inflation * (1 - thisLossRate * Time.fixedDeltaTime);
		if (wantsToInflate && heat < 1f) {
			inflation += inflateRate * Time.fixedDeltaTime;
			heat += inflateHeatRate * Time.fixedDeltaTime;
		}
		heat = Mathf.Max (heat - cooldownRate * Time.fixedDeltaTime, 0f);
		inflation = Mathf.Clamp(inflation, 0f, 1f);
		float buoyantForce = inflation * maxBuoyantForce;
		rigidbody.AddForce (Vector3.up * buoyantForce);
	}
}
