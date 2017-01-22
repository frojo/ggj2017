using UnityEngine;
using System.Collections;

public class SkillActivator : MonoBehaviour {

    public GameObject pusher;
	public GameObject attracter;
	public GameObject disruptor;

    public TikiBehavior tiki;
    public float energyCost = 1;

	public int skillNumber;

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

			Vector2 mouse_world_position = 
				Camera.main.ScreenToWorldPoint (
					Input.mousePosition);

			switch (skillNumber) {
			case 1:
				InstantiatePusher (mouse_world_position);
				break;
			case 2:
				InstantiateAttracter (mouse_world_position);
				break;
			case 3:
				InstantiateDisruptor ();
				break;
			default:
				break;
			}
        }
    }

	void InstantiateDisruptor() {
		Instantiate (disruptor);
	}

	void InstantiateAttracter(Vector2 mouse_world_position) {
		attracter.transform.position = mouse_world_position;
		Instantiate (attracter);
	}

    void InstantiatePusher(Vector2 mouse_world_position) {

        Vector2 start_point = transform.position;
        pusher.GetComponent<Pusher>().start_point = start_point;
        pusher.GetComponent<Pusher> ().direction = 
            (mouse_world_position - start_point).normalized;

        Instantiate (pusher);
    }
}
