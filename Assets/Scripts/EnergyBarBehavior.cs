using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyBarBehavior : MonoBehaviour {

    public float maxEnergy = 100;
    public float energyGainRate = 5; // per sec
    public float currentEnergy { get; private set; }
    /*
    private Vector2 maxDimension;
    private Vector3 localScale;

    private RectTransform rectTransform;
    */
    private Image image;
    public static EnergyBarBehavior instance { get; private set; }

    void Awake ()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    void Start () {
        /*
        rectTransform = GetComponent<RectTransform>();

        maxDimension = rectTransform.sizeDelta;
        localScale = rectTransform.sizeDelta;
        localScale.x = 0;
        rectTransform.sizeDelta = localScale;
        */
        image = GetComponent<Image>();
        currentEnergy = 0;
    }
    
    void Update () {
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
        /*
        localScale.x = maxDimension.x * currentEnergy / maxEnergy;
        rectTransform.sizeDelta = localScale;
        */
        image.fillAmount = currentEnergy / maxEnergy;
    }

    public bool ConsumeEnergy(float amount)
    {
        if (currentEnergy < amount)
        {
            return false;
        }

        currentEnergy -= amount;
        return true;
    }
}
