using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

	public Vector2 start_point;
	public Vector2 end_point;

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Move towards end point
		transform.position = 
			Vector2.MoveTowards (transform.position, end_point, speed * Time.deltaTime);

		// Disappear once it gets to the end
		if (((Vector2)transform.position) == end_point) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			other.GetComponent<Surfer>().InitiatePush(end_point, speed);
		}

	}
}
