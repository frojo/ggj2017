using UnityEngine;
using System.Collections;

public class FaceMouse2D : MonoBehaviour {

    void Update () {
        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var relDir = worldMousePos - transform.position;
        relDir.Normalize();
        var angles = transform.eulerAngles;
        angles.z = Mathf.Atan2(relDir.y, relDir.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = angles;
    }
}
