using UnityEngine;
using System.Collections;

public class WaveWipe : MonoBehaviour {

	public Vector2 start_pos;
	public GameObject target;
	public float speed;

	// Use this for initialization
	void Start () {
		print ("Hi I am wave!");
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (
			transform.position,
			target.transform.position,
			speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D other) {
		print ("Hi!");
		if (other.gameObject == target) {
			Destroy (gameObject);
		}
		
	}
}
