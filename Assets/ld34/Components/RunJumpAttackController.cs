using UnityEngine;
using System.Collections;

public class RunJumpAttackController : MonoBehaviour {
	public float maxVelocityZ = 5f;
	public float acceleration = 5f;
	public float jumpVelocity = 2f;
	Rigidbody rigidbody;
	Animator animator;

	void Start () {
		rigidbody = GetComponentInParent<Rigidbody> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	void FixedUpdate () {
		rigidbody.AddForce (transform.forward * acceleration);
		Vector3 velocity = rigidbody.velocity;
		animator.SetFloat ("Forward", velocity.z);
		if (Input.GetKeyDown (KeyCode.Space)) {
			velocity.y += jumpVelocity;
			animator.SetTrigger("Jump");
		}
		if (Input.GetMouseButtonDown(0)) {
			animator.SetBool ("Punching", true);
		} else {
			animator.SetBool ("Punching", false);
		}
		velocity.z = Mathf.Clamp(velocity.z,  -maxVelocityZ, maxVelocityZ);
		rigidbody.velocity = velocity;
	}
}
