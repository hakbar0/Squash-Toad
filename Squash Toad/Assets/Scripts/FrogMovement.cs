using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {

	public float jumpSpeedInMps = 5;
	public float jumpElevationInDegrees = 45;
	public float jumpGroundClearance = 2;
	public float JumpSpeedTol = 5;

	public int collisionCount = 0;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(){
		collisionCount++;
	}

	void OnCollisionExit(){
		collisionCount--;
	}
	
	// Update is called once per frame
	void Update () {

		bool isOnGround = collisionCount > 0;

		if (GvrViewer.Instance.Triggered && isOnGround ) {
			var camera = GetComponentInChildren<Camera> ();
			var projectedLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
			var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
			var unnormalisedRotatedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0 );
			var jumpVector = unnormalisedRotatedJumpDirection.normalized * jumpSpeedInMps;
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
