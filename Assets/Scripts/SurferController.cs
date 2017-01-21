using UnityEngine;
using System.Collections;

public class SurferController : MonoBehaviour {

	public GameObject island;
	private Vector2 island_position;

	// How fast the surfer approaches the island
	public float speed;

	// Use this for initialization
	void Start () {
		island_position = island.transform.position;


		// TODO: Find the island
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = 
			Vector2.MoveTowards (transform.position, island_position, speed * Time.deltaTime);
		
	
	}
}
