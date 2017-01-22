using UnityEngine;
using System.Collections;

public class Disruptor : MonoBehaviour {

	GameObject island;

	public float speed;
	public float radius;

	public float start_angle;
	public float current_angle;


	Vector2 orbitCenter;

	// Use this for initialization
	void Start () {
		island = GameObject.FindGameObjectWithTag ("Island");
		orbitCenter = island.transform.position;

		Vector2 start_position = 
			PositionFromAngleMagnitude (start_angle, radius) + 
			orbitCenter;
		transform.position = start_position;

		current_angle = start_angle;
		transform.Rotate (Vector3.forward*current_angle);

	}

	Vector2 PositionFromAngleMagnitude(float angle, float magnitude) {
		return new Vector2 (
			Mathf.Sin (angle), 
			Mathf.Cos (angle)) * radius;
	}


	// Update is called once per frame
	void Update () {

		current_angle -= speed * Time.deltaTime;

		Vector2 new_position = 
			PositionFromAngleMagnitude (current_angle, radius) + orbitCenter;

		print ("New position is " + new_position);
		transform.position = new_position;
		transform.eulerAngles = new Vector3 (0, 0, -Mathf.Rad2Deg*current_angle);


		
	
	}
}
