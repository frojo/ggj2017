using UnityEngine;
using System.Collections;

public class FollowMouse2D : MonoBehaviour {

	void Update () {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
