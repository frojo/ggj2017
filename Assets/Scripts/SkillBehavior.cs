using UnityEngine;
using System.Collections;

public class SkillBehavior : MonoBehaviour {

    public KeyCode hotkey = KeyCode.Q;
    public float energyCost = 10;
    private EnergyBarBehavior energybar;

    void Start () {
        energybar = EnergyBarBehavior.instance;
    }

    public void Update()
    {
        if (Input.GetKeyDown(hotkey))
        {
            OnClick();
        }
    }
    
    public void OnClick ()
    {
        if (energybar.ConsumeEnergy(energyCost))
        {
            Debug.Log("Skill Activated!");
        }
        else
        {
            Debug.Log("Not enough energy!");
        }
    }
}
