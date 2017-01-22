using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AnimationAngleSelector))]
public class Surfer : MonoBehaviour {

	// Island that the surfer is approaching
	private GameObject island;
	Vector2 island_position;

	// How fast the surfer approaches the island
	public float surf_speed;

	Vector2 end_point;
	float speed;

	float push_speed;

    AnimationAngleSelector angleSelector;

    // Use this for initialization
    void Start () {
        island = GameObject.FindGameObjectWithTag("Island");
        Debug.Assert(island != null, "no island found!", this);
        island_position = island.transform.position;
		end_point = island_position;
		speed = surf_speed;

        angleSelector = GetComponent<AnimationAngleSelector>();
        angleSelector.DisableAll();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateVisual();
		transform.position = 
			Vector2.MoveTowards (transform.position, end_point, speed * Time.deltaTime);
    }

    void UpdateVisual ()
    {
        var dir = island_position - new Vector2(transform.position.x, transform.position.y);
        angleSelector.SetDirection(dir);
    }
}
