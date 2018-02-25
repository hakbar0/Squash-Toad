﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour {

	public GameObject[] lanePrefabs;

	// Use this for initialization
	void Start () {
		CreateRandomLane (0);
		CreateRandomLane (10);
		CreateRandomLane (20);
		CreateRandomLane (30);
	}

	void CreateRandomLane(float offset) {
		int laneIndex = Random.Range (0, lanePrefabs.Length);
		var lane = Instantiate (lanePrefabs [laneIndex]);
		lane.transform.parent = transform;
		lane.transform.Translate (0, 0, offset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}