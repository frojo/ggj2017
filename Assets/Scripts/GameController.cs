using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject wave_controller;
	public GameObject lose_text;
    public GameObject win_text;

	public GameObject title_screen;

	public GameObject[] premiseScreens;
	private int premiseScreenNum = -1;
//	public GameObject premise_screen1;
//	public GameObject premise_screen2;
//	public GameObject premise_screen3;

	public GameObject[] gameobjectsToActivateOnStart;

    public GameObject[] onEndListeners;

	void Start () {
		lose_text.SetActive (false);
		win_text.SetActive (false);
        wave_controller = GameObject.FindGameObjectWithTag ("WaveController");


    }

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			if (premiseScreenNum < premiseScreens.Length) {
				NextScreen ();
			}
		}
	}

	private void NextScreen() {
		if (premiseScreenNum < 0) {
			title_screen.SetActive (false);
		} else {
			premiseScreens [premiseScreenNum].SetActive (false);
		}

		premiseScreenNum++;
		if (premiseScreenNum == premiseScreens.Length) {
			StartGamePlay ();
		} else {
			premiseScreens [premiseScreenNum].SetActive (true);
		}

	}

	public void StartGamePlay() {
		foreach (var obj in gameobjectsToActivateOnStart) {
			obj.SetActive (true);
		}
	}

	public void EndGame(bool win) {
		if (win) {
				win_text.SetActive(true);
            foreach (var o in onEndListeners)
            {
                o.SendMessage("OnWin", SendMessageOptions.DontRequireReceiver);
            }
		} else {
            wave_controller.GetComponent<WaveController>().EndCurrentWave();

                lose_text.SetActive (true);
            foreach (var o in onEndListeners)
            {
                o.SendMessage("OnLose", SendMessageOptions.DontRequireReceiver);
            }
        }

    }
}
