using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public GameObject UICanvas;

	public void onDeath(){
		Debug.Log ("hello");
		UICanvas.SetActive (true);
	}
}
