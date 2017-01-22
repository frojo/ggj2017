﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attracter : MonoBehaviour {

	public GameObject island;
	public float duration;

	// Keeps track of attractd surfers
	List<GameObject> attracted_enemies;

	// Use this for initialization
	void Start () {
		island = GameObject.FindGameObjectWithTag ("Island");

		attracted_enemies = new List<GameObject> ();

		StartCoroutine (DisappearInXSeconds (duration));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator DisappearInXSeconds(float x) {
		yield return new WaitForSeconds (x);
		foreach (GameObject enemy in attracted_enemies) {
			enemy.GetComponent<Surfer> ().end_point =
				island.transform.position;
		}
		print ("Okay time to destroy things!");
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			print ("Surfer in mermaid!");
			attracted_enemies.Add (other.gameObject);
			other.GetComponent<Surfer> ().end_point = 
				transform.position;
		}
		// Make that thing come to the mermaid
	}
}