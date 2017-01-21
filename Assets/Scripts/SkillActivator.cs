using UnityEngine;
using System.Collections;

public class SkillActivator : MonoBehaviour {

    //public Transform skill;

    void Start () {
    
    }
    
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Launching skill!");
            gameObject.SetActive(false);
        }
    }
}
