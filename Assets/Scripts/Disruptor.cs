using UnityEngine;
using System.Collections;

public class Disruptor : MonoBehaviour {

	GameObject island;
	public GameObject tempSurferTarget;

	public float speed;
	public float radius;

	public float start_angle;
	public float current_angle;
	public Vector2 center_offset;

	public float disruption;


	Vector2 orbitCenter;

	// Use this for initialization
	void Start () {
		island = GameObject.FindGameObjectWithTag ("Island");
		orbitCenter = (Vector2)island.transform.position - center_offset;

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

		if (current_angle < -start_angle) {
			Destroy (gameObject);
		}

		current_angle -= speed * Time.deltaTime;

		Vector2 new_position = 
			PositionFromAngleMagnitude (current_angle, radius) + orbitCenter;

		transform.position = new_position;
		transform.eulerAngles = new Vector3 (0, 0, -Mathf.Rad2Deg*current_angle);
	}

	Vector2 FindDisruptedEndPoint(Vector2 current_position) {
		Vector2 norm_direction = 
			(current_position - (Vector2)island.transform.position).normalized;
		float random_variation = Random.value < 0.5 ? 1 : -1;
		Vector2 disruption_vector = norm_direction * disruption + Vector2.right * random_variation;
		return current_position + disruption_vector;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Vector2 new_end_point = 
				FindDisruptedEndPoint (other.transform.position);
			//other.transform.position = new_end_point;

			tempSurferTarget.transform.position = new_end_point;
			tempSurferTarget.GetComponent<TempSurferTarget> ().designatedSurfer = other.gameObject;
			Instantiate (tempSurferTarget);

			other.GetComponent<Surfer> ().end_point = new_end_point;
			// Figure out what temporary end_point is (it 
			// should be radially outwards a bit of a ways from
			// where they currently are)

			// Then instantiate a TempSurferTarget there
			// TempSurferTarget.designatedSurfer = other.gameObject
			// other.Surfer.end_point = new_end_point
		}

	}
}
