using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyBarBehavior : MonoBehaviour {

    public float maxEnergy = 100;
    public float energyGainRate = 5; // per sec
    public float currentEnergy { get; private set; }

    private Image image;
    public static EnergyBarBehavior instance { get; private set; }

	public GameObject wave_controller;

    void Awake ()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    void Start () {
        image = GetComponent<Image>();
		wave_controller = GameObject.FindGameObjectWithTag ("WaveController");

        currentEnergy = 0;
    }
    
    void Update () {
		if (currentEnergy == maxEnergy) {
			wave_controller.GetComponent<WaveController>().NextWave ();
		}
        IncreaseEnergy(Time.deltaTime);
        UpdateVisual();
    }

    void IncreaseEnergy(float dt)
    {
        currentEnergy += energyGainRate * dt;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    void UpdateVisual()
    {
        image.fillAmount = currentEnergy / maxEnergy;
    }

    public bool HasEnergy(float amount)
    {
        return currentEnergy >= amount;
    }

    public bool ConsumeEnergy(float amount)
    {
        if (!HasEnergy(amount))
        {
            return false;
        }

        currentEnergy -= amount;
        return true;
    }
}
