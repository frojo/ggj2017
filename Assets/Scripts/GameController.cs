using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject lose_text;

	// Use this for initialization
	void Start () {
		lose_text.SetActive (false);

		// Should we do anything?
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndGame() {
		lose_text.SetActive (true);
		
	}
}
