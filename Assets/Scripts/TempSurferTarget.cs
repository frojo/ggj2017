using UnityEngine;
using System.Collections;

public class TempSurferTarget : MonoBehaviour {

	GameObject island;
	public GameObject designatedSurfer;


	// Use this for initialization
	void Start () {
		island = GameObject.FindGameObjectWithTag ("Island");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject == designatedSurfer) {
			designatedSurfer.GetComponent<Surfer> ().end_point = island.transform.position;
			Destroy (gameObject);
		}

	}
}
