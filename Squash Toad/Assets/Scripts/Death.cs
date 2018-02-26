using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public GameObject UICanvas;
	public GameObject Reticule;

	public void onDeath(){
		UICanvas.SetActive (true);
		Reticule.SetActive (true);
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
