using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class DestroyAfterAnimation : MonoBehaviour {

    private Animation mAnimation;

    void Start () {
        mAnimation = GetComponent<Animation>();
    }
    
    void Update () {
        if (!mAnimation.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
