using UnityEngine;
using System.Collections;

public class SkillActivator : MonoBehaviour {

    public GameObject pusher;
    public TikiBehavior tiki;

    void OnEnable ()
    {
        tiki.enabled = true;
    }

    void OnDisable ()
    {
        tiki.enabled = false;
    }

    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);
            InstantiatePusher (
                Camera.main.ScreenToWorldPoint (Input.mousePosition));
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
