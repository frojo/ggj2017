using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// The thing to spawn
	public GameObject spawnee;

	// Instantiates spawnee at 
	public void Spawn(GameObject spawnee) {
		print ("Spawnee is " + spawnee);
		GameObject spawned = Instantiate (spawnee);
		print ("Just instantiated " + spawned);
		spawned.transform.position = transform.position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			print ("click!");
			Spawn(this.spawnee);
		}
	
	}
}
