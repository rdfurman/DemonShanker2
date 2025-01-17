﻿using UnityEngine;
using System.Collections;

public class WalkAI : MonoBehaviour {

	private GameObject[] destinations;
	public int currentDestIndex = 0;
	
	private UnityEngine.AI.NavMeshAgent nva;
	
	void Awake() {

		GameObject[] allPois = GameObject.FindGameObjectsWithTag("pois");

		GameObject poi1 = allPois[Random.Range (0, allPois.Length)];
		GameObject poi2 = allPois[Random.Range (0, allPois.Length)];
		while (poi2 == poi1) {
		 	poi2 = allPois[Random.Range (0, allPois.Length)];
		}

		Debug.Log (poi1.name + "," + poi2.name);

		destinations = new GameObject[2] {
			poi1,
			poi2
		};

		nva = GetComponent<UnityEngine.AI.NavMeshAgent>();
		nva.updateRotation = false;
		nva.SetDestination(destinations[currentDestIndex].transform.position);
	}
	
	public void NextDest() {
		if(currentDestIndex + 1 < destinations.Length)
			++currentDestIndex;
		else
			currentDestIndex = 0;
		
		nva.SetDestination(destinations[currentDestIndex].transform.position);
	}
}
