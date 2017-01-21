﻿using UnityEngine;
using System.Collections;

public class SkillActivator : MonoBehaviour {

    public GameObject pusher;

    void Start () {
    
    }
    
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            InstantiatePusher (
                Camera.main.ScreenToWorldPoint (Input.mousePosition));
            gameObject.SetActive(false);
        }
    }

    void InstantiatePusher(Vector2 mouse_world_position) {

        Vector2 start_point = transform.position;
        pusher.GetComponent<Pusher>().start_point = start_point;
        pusher.GetComponent<Pusher> ().direction = 
            (mouse_world_position - start_point).normalized;

        Instantiate (pusher);
    }
}