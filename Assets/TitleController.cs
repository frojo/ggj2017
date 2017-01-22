using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	public GameObject title_screen;

	public GameObject[] premiseScreens;
	private int premiseScreenNum = -1;

	private void NextScreen() {
		if (premiseScreenNum < 0) {
			title_screen.SetActive (false);
		} else {
			premiseScreens [premiseScreenNum].SetActive (false);
		}

		premiseScreenNum++;
		if (premiseScreenNum == premiseScreens.Length) {
			//StartGamePlay ();
			SceneManager.LoadScene("Main");
			print ("start game!");
		} else {
			premiseScreens [premiseScreenNum].SetActive (true);
		}

	}

	// Use this for initialization
	void Start () {
	
	}

	public void StartGamePlay() {
		//
//		foreach (var obj in gameobjectsToActivateOnStart) {
//			obj.SetActive (true);
//		}
	}
	
	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			if (premiseScreenNum < premiseScreens.Length) {
				NextScreen ();
			}
		}
	}
}
