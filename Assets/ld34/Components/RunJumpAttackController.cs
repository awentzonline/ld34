using UnityEngine;
using System.Collections;

public class RunJumpAttackController : MonoBehaviour {
	public float maxVelocityZ = 5f;
	public float acceleration = 5f;
	public float jumpVelocity = 2f;
	public AudioClip jumpSound;
	Rigidbody rigidbody;
	Animator animator;
	AudioSource audioSource;

	void Start () {
		rigidbody = GetComponentInParent<Rigidbody> ();
		animator = GetComponentInChildren<Animator> ();
		audioSource = GetComponentInParent<AudioSource> ();
	}
	
	void FixedUpdate () {
		rigidbody.AddForce (transform.forward * acceleration);
		Vector3 velocity = rigidbody.velocity;
		if (Input.GetKeyDown (KeyCode.Space)) {	
			velocity.y = jumpVelocity;
			animator.SetTrigger ("Jump");
			if (jumpSound) {
				audioSource.PlayOneShot (jumpSound);
			}
		}
		if (Input.GetMouseButtonDown(0)) {
			animator.SetBool ("Punching", true);
		} else {
			animator.SetBool ("Punching", false);
		}
		velocity.z = Mathf.Clamp(velocity.z,  -maxVelocityZ, maxVelocityZ);
		animator.SetFloat ("Forward", velocity.z / maxVelocityZ);
		rigidbody.velocity = velocity;
	}
}
