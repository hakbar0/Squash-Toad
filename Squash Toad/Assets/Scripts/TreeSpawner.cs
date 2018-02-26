using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	public GameObject TreePrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range(2,15); i++) {
			CreateTree ();
		}
	}

	void CreateTree(){
		var tree = Instantiate (TreePrefab);
		tree.transform.parent = transform;
		tree.transform.localPosition = new Vector3 (Random.Range(-5000,5000), 0, Random.Range(-500,500));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
