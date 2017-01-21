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

	// Use this for initialization
	void Start () {
		print ("Starting waves!");
		StartCoroutine (Wave1 ());
	
	}

	public IEnumerator Wave1(){
		tm_spawner.GetComponent<Spawner> ().Spawn (baby_surfer);
		yield return new WaitForSeconds (4);
		StartCoroutine(Wave1 ());
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
