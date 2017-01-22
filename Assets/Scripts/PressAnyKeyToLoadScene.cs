using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PressAnyKeyToLoadScene : MonoBehaviour {

    public int sceneIndex = 1;

    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}
