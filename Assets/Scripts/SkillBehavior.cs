using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class SkillBehavior : MonoBehaviour {

    public KeyCode hotkey = KeyCode.Q;
    public float energyCost = 10;
    private EnergyBarBehavior energybar;
    private Button button;
    public GameObject [] activationListeners;

    void Start () {
        energybar = EnergyBarBehavior.instance;
        button = GetComponent<Button>();
    }

    public void Update()
    {
        button.interactable = (energybar.currentEnergy >= energyCost);

        if (Input.GetKeyUp(hotkey))
        {
            button.onClick.Invoke();
        }
    }
    
    public void OnClick ()
    {
        if (energybar.ConsumeEnergy(energyCost))
        {
            foreach (GameObject o in activationListeners)
            {
                o.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Not enough energy!");
        }
    }
}
