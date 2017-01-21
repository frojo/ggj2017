using UnityEngine;
using System.Collections;

// TODO: Think of a better name for this 
// class because I mean goddamn Francisco, really?
public class InputListener : MonoBehaviour {

	public Camera main_camera;
	public GameObject pusher;
	public GameObject island;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			print (Input.mousePosition);
			print (main_camera.ScreenToWorldPoint (Input.mousePosition));


			InstantiatePusher (
				main_camera.ScreenToWorldPoint (Input.mousePosition));

		}
	
	}

	void InstantiatePusher(Vector2 mouse_world_position) {

		print ("island position = " + island.transform.position);

		Vector2 start_point = island.transform.position;
		pusher.GetComponent<Pusher>().start_point = start_point;
		pusher.GetComponent<Pusher> ().direction = 
			(mouse_world_position - start_point).normalized;

		Instantiate (pusher);



	}
}
