using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject lose_text;
	public GameObject win_text;

	// Use this for initialization
	void Start () {
		lose_text.SetActive (false);
		win_text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndGame(bool win) {
		if (win) {
				win_text.SetActive(true);
		} else {
				lose_text.SetActive (true);
		}

		// Turn off powers
		// Turn off spawners

		
	}
}
