﻿using UnityEngine;
using System.Collections;

public class Patron : MonoBehaviour {
	public Renderer characterSprite;
	public Renderer demonHead;
	public AudioClip demonDeath;
	public AudioClip patronDeath;

	private GameController gameController;
	private bool isDemon = false;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController> ();
		else
			Debug.Log("Cannot find GameController script.");

		if (Random.value >= 0.75 || gameController.currentNumberOfDemons < (gameController.patronCounter / 4)) {
			isDemon = true;
			gameController.currentNumberOfDemons++;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Shank") 
		{
			if(isDemon) {
				AudioSource.PlayClipAtPoint (demonDeath, gameObject.GetComponent<Rigidbody>().position);
				gameController.AddScore ();
			}
			else {
				AudioSource.PlayClipAtPoint (patronDeath, gameObject.GetComponent<Rigidbody>().position);
				gameController.DetractScore ();
			}

			Destroy(gameObject);
		}

		if (other.tag == "VVAura" && isDemon) {
			characterSprite.GetComponent<Renderer>().material.color = Color.red;
			demonHead.GetComponent<Renderer>().enabled = true;
		}
	}
}
