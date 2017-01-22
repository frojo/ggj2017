using UnityEngine;
using System.Collections;

public class ActivateOnWinLose : MonoBehaviour {

    public GameObject[] gameobjectsToActivateOnWin;
    public GameObject[] gameobjectsToActivateOnLose;
    public GameObject[] gameobjectsToDeactivateOnWin;
    public GameObject[] gameobjectsToDeactivateOnLose;

    void OnWin ()
    {
        foreach (var obj in gameobjectsToActivateOnWin)
        {
            obj.SetActive(true);
        }
        foreach (var obj in gameobjectsToDeactivateOnWin)
        {
            obj.SetActive(false);
        }
    }

    void OnLose ()
    {
        foreach (var obj in gameobjectsToActivateOnLose)
        {
            obj.SetActive(true);
        }
        foreach (var obj in gameobjectsToDeactivateOnLose)
        {
            obj.SetActive(false);
        }
    }
}
