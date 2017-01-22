using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(SpriteSheetAnimation))]
public class SpriteSheetAnimationDelay : MonoBehaviour {

    public float inDelay;
    public float animationDuration;
    public float outDelay;
    public Sprite outSprite;

    private SpriteRenderer spriteRenderer;
    private SpriteSheetAnimation spriteSheetAnimation;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSheetAnimation = GetComponent<SpriteSheetAnimation>();
        spriteSheetAnimation.enabled = false;
    }

    IEnumerator Start () {
        yield return new WaitForSeconds(inDelay);
        spriteSheetAnimation.enabled = true;
        yield return new WaitForSeconds(animationDuration);
        spriteSheetAnimation.enabled = false;
        spriteRenderer.sprite = outSprite;
        yield return new WaitForSeconds(outDelay);
        Destroy(gameObject);
    }
}
