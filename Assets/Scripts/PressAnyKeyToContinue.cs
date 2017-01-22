using UnityEngine;
using System.Collections;

public class PressAnyKeyToContinue : MonoBehaviour {

    public GameObject next;

    void Update () {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            next.SetActive(true);
        }
    }
}
