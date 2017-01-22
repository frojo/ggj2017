using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AnimationAngleSelector))]
public class TikiBehavior : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private AnimationAngleSelector angleSelector;

    void Awake () {
        angleSelector = GetComponent<AnimationAngleSelector>();
    }

    void OnEnable()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        spriteRenderer.enabled = false;
    }

    void OnDisable()
    {
        spriteRenderer.enabled = true;
        angleSelector.DisableAll();
    }
    
    void Update () {
        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var relDir = worldMousePos - transform.position;
        angleSelector.SetDirection(relDir);

        if (Input.GetMouseButtonUp(0))
        {
            enabled = false;
        }
    }
}
