using UnityEngine;
using System.Collections;

public class DetachFromParent : MonoBehaviour {

    void Start () {
        transform.parent = null;
        Destroy(this);
    }
}
