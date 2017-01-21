using UnityEngine;
using System.Collections;

public class CopyParentPosition : MonoBehaviour {

    private Transform parent;

    void Start () {
        parent = transform.parent;
        transform.parent = null;

        var angles = transform.eulerAngles;
        angles.z = 0;
        transform.eulerAngles = angles;
    }
    
    void LateUpdate () {
        if (parent)
        {
            transform.position = parent.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
