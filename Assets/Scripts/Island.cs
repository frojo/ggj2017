using UnityEngine;
using System.Collections;

public class Island : MonoBehaviour {

	public GameObject game_controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Enemy") {
			// TODO: Do something besides just destroying the surfer
			Destroy(other.gameObject);


			game_controller.GetComponent<GameController>().EndGame ();
		}
	}
}
