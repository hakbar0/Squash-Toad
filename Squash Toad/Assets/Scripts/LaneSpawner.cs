using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour
{

	enum LaneType
	{
Safe,
		Danger}

	;

	public GameObject[] safelanePrefabs;
	public GameObject[] dangerouslanePrefabs;
	LaneType lastLaneType = LaneType.Safe;
	public float safeLaneRunProbablitiy = 0.2f;

	// Use this for initialization
	void Start ()
	{
		int offset = 0;
		while (offset < 50000) {
			CreateRandomLane (offset);
			offset += 1000;

		}
	}

	void CreateRandomLane (float offset)
	{
		GameObject lane = null;
		if (lastLaneType == LaneType.Safe) {
			
			if (Random.value < safeLaneRunProbablitiy) {
				lastLaneType = LaneType.Safe;
				lane = InstiantiateRandomLane (safelanePrefabs);
			} 

			lastLaneType = LaneType.Danger;
			lane = InstiantiateRandomLane (dangerouslanePrefabs);
		} 

		else {
			lastLaneType = LaneType.Safe;
			lane = InstiantiateRandomLane (safelanePrefabs);
		}

		lane.transform.SetParent (transform, false);
		lane.transform.Translate (0, 0, offset);
	}

	GameObject InstiantiateRandomLane (GameObject[] lanes)
	{
		int laneIndex = Random.Range (0, lanes.Length);
		return Instantiate (lanes [laneIndex]);

	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
