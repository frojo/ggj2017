using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject bl_spawner;
	public GameObject fl_spawner;
	public GameObject tl_spawner;
	public GameObject tm_spawner;
	public GameObject tr_spawner;
	public GameObject fr_spawner;
	public GameObject br_spawner;

	public GameObject baby_surfer;

	public GameObject energy_bar;
	public GameObject game_controller;

	public GameObject[] waveTexts;
	public GameObject waveWipe;

	int current_wave = 0;

	// Use this for initialization
	void Start () {
		print ("Starting waves!");
		energy_bar = GameObject.FindGameObjectWithTag ("EnergyBar");
		game_controller = GameObject.FindGameObjectWithTag ("GameController");

		StartCoroutine(ShowWaveText (0));
		StartCoroutine (WaveA0 ());
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown("r")) {
//			current_wave = -1;
//			NextWave ();
//		}
	}

	public void EndCurrentWave() {
		// Kill all the enemies on screen
		GameObject[] all_enemies = GameObject.FindGameObjectsWithTag("Enemy");

        StopAllCoroutines();
		foreach (GameObject enemy in all_enemies) {
			Destroy (enemy);
		}
		energy_bar.GetComponent<EnergyBarBehavior> ().ConsumeEnergy (
			energy_bar.GetComponent<EnergyBarBehavior> ().maxEnergy);
		print ("Done destroying Surfers!");
	}

	public void NextWave() {
		current_wave++;
		EndCurrentWave ();
		switch (current_wave) {
		case 1:
			StartCoroutine(ShowWaveText (2));
			StartCoroutine (WaveB0());
			break;
		case 2:
			//ShowWaveText (1);
			StartCoroutine(ShowWaveText (3));
			StartCoroutine (WaveC0());
			break;
		case 3:
			//ShowWaveText (2);
			game_controller.GetComponent<GameController>().EndGame (true);
			break;
		}
	}


	public IEnumerator ShowWaveText (int waveNum){
		waveTexts[waveNum].SetActive(true);
		yield return new WaitForSeconds (3);
		waveTexts[waveNum].SetActive(false);
	}

	// FIRST WAVE
		
	public IEnumerator WaveA0(){
		tm_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveA1 ());
	}

	public IEnumerator WaveA1(){
		tm_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveA2 ());
	}

	public IEnumerator WaveA2(){
		tl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveA3 ());
	}

	public IEnumerator WaveA3(){
		tr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (0);
		//EndWaveA ();
		//StartCoroutine(Wave1 ());
	}

	// SECOND WAVE

	public IEnumerator WaveB0(){
		tm_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveB1 ());
	}

	public IEnumerator WaveB1(){
		bl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		br_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveB2 ());
	}

	public IEnumerator WaveB2(){
		fl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		fr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		tl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		tr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (99999);
//		StartCoroutine(WaveB3 ());
	}

	// THIRD WAVE

	public IEnumerator WaveC0(){
		// Spawn all right
		fr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		tr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		br_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveC1 ());
	}

	public IEnumerator WaveC1(){
		// Spawn all left
		fl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		tl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		bl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
		StartCoroutine(WaveC2 ());
	}

	public IEnumerator WaveC2(){
		// Spawn All
		tm_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		fl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		fr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		tl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		tr_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		bl_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		br_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (2);
//		StartCoroutine(WaveC ());
	}





}
