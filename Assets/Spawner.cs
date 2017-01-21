using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// The thing to spawn
	public GameObject spawnee;

	// Instantiates spawnee at 
	void Spawn(GameObject spawnee) {
		GameObject spawned = Instantiate (spawnee);
		spawned.transform.position = transform.position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			print ("click!");
			Spawn(this.spawnee);
		}
	
	}
}
