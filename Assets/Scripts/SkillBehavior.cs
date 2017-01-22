using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class SkillBehavior : MonoBehaviour {

    public KeyCode hotkey = KeyCode.Q;
    private EnergyBarBehavior energybar;
    private Button button;
    public SkillActivator skillActivator;

    void Start () {
        energybar = EnergyBarBehavior.instance;
        button = GetComponent<Button>();
        Debug.Assert(skillActivator != null, "no skill activator set", this);
    }

    public void Update()
    {
        button.interactable = (energybar.currentEnergy >= skillActivator.energyCost);

        if (Input.GetKeyUp(hotkey))
        {
            button.onClick.Invoke();
        }
    }
    
    public void OnClick ()
    {
        if (energybar.HasEnergy(skillActivator.energyCost))
        {
            skillActivator.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough energy!");
        }
    }
}
