using UnityEngine;
using System.Collections;

public class SurferOwSpriteSwapper : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    SpriteSheetAnimation spriteSheetAnimation;
    public Sprite owSprite;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSheetAnimation = GetComponent<SpriteSheetAnimation>();

        Debug.Assert(spriteRenderer != null, "sprite renderer not set", this);
        Debug.Assert(spriteSheetAnimation != null, "sprite sheet animation not set", this);
    }
    
    void StartOw () {
        spriteSheetAnimation.enabled = false;
        spriteRenderer.sprite = owSprite;
    }

    void EndOw ()
    {
        spriteSheetAnimation.enabled = true;
    }
}
