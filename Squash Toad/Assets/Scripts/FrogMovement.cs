using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {

	public float jumpSpeedInMps = 5;
	public float jumpElevationInDegrees = 45;
	public float jumpGroundClearance = 2;
	public float JumpSpeedTol = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		bool isOnGround = Physics.Raycast (transform.position, -transform.up, jumpGroundClearance);

		var speed = GetComponent<Rigidbody> ().velocity.magnitude;
		bool isNearStationary = speed < JumpSpeedTol;
		if (GvrViewer.Instance.Triggered && isOnGround && isNearStationary) {
			var camera = GetComponentInChildren<Camera> ();
			var projectedLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
			var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
			var unnormalisedRotatedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0 );
			var jumpVector = unnormalisedRotatedJumpDirection.normalized * jumpSpeedInMps;
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
