using UnityEngine;
using System.Collections;

public class SkillActivator : MonoBehaviour {

    public GameObject pusher;
    public TikiBehavior tiki;
    public float energyCost = 1;

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
            EnergyBarBehavior.instance.ConsumeEnergy(energyCost);
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
