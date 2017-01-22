using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public void Load (int levelIndex) {
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
