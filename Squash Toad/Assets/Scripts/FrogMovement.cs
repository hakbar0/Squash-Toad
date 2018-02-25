using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {

	public float jumpSpeedInMps = 5;
	public float jumpElevationInDegrees = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		var camera = GetComponentInChildren<Camera> ();

		Debug.DrawRay (transform.position, 	camera.transform.forward, Color.red);

		var projectedLookDirection = Vector3.ProjectOnPlane (camera.transform.forward, Vector3.up);
		var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
		var unnormalisedRotatedJumpDirection = Vector3.RotateTowards (projectedLookDirection, Vector3.up, radiansToRotate, 0 );
		var jumpVector = unnormalisedRotatedJumpDirection.normalized * jumpSpeedInMps;
		Debug.DrawRay (transform.position, jumpVector, Color.blue);


		if (Input.GetKeyDown (KeyCode.Space)) {
	
			GetComponent<Rigidbody> ().AddForce (jumpVector, ForceMode.VelocityChange);
		}
	}
}
