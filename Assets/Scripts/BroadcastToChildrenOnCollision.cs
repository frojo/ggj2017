using UnityEngine;
using System.Collections;

public class BroadcastToChildrenOnCollision : MonoBehaviour {

    public string messageOnCollisionEnter;
    public string messageOnCollisionExit;

    float timeLastDetectedCollision;
    public float delayToNormalize = 0.5f;

    void Start ()
    {
        enabled = false;
    }

    void OnCollisionEnter2D ()
    {
        BroadcastMessage(messageOnCollisionEnter);
        timeLastDetectedCollision = Time.time;
        enabled = true;
    }

    void OnCollisionStay2D ()
    {
        timeLastDetectedCollision = Time.time;
    }

    void Update ()
    {
        if (Time.time > timeLastDetectedCollision + delayToNormalize)
        {
            BroadcastMessage(messageOnCollisionExit);
            enabled = false;
        }
    }
}
