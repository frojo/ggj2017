using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private GameObject wave_controller;
	public GameObject lose_text;
    public GameObject win_text;

    public GameObject[] onEndListeners;

	void Start () {
		lose_text.SetActive (false);
		win_text.SetActive (false);
        wave_controller = GameObject.FindGameObjectWithTag ("WaveController");


    }

	void Update() {

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
