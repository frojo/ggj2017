using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

	public Camera main_camera;

	// Island that the pusher is being sent out from
	//public GameObject island;

	public Vector2 start_point;
	public Vector2 end_point;

	public Vector2 direction;

	public float speed;

	// Constant to compute end_point for a new Pusher
	public float far_enough;

	// Use this for initialization
	void Start () {
		transform.position = start_point;
		end_point = start_point + direction*far_enough;

		// Rotate pusher so that it goes in straight line
		float angle = AngleBetweenTwoVectors (start_point, end_point);
		transform.Rotate (Vector3.forward*angle);
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

	// Suicide when out of bounds
	void OnBecomeInvisible() {
		Destroy (gameObject);
	}

	// Converts screen coordinates to a world position
	void ScreenCoordsToWorldPosition(Vector2 screen_coordinates) {

	}

	float AngleBetweenTwoVectors(Vector2 a, Vector2 b) {
		Vector2 difference = b - a;
		float sign = (b.x < a.x)? 1.0f : -1.0f;
		float angle = Vector2.Angle(Vector2.up, difference) * sign;
		return angle;
	}
		

}
