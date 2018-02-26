﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public float spawnInterval = 1;
	public float spawnIntervalMax = 4;
	float nextSpawnTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime) {
			Spawn ();
			nextSpawnTime = Time.time + Random.Range(spawnInterval, spawnIntervalMax);
		}
	}
	void Spawn(){
		var instance = Instantiate (prefab, transform.position, transform.rotation, transform);
	}
}
