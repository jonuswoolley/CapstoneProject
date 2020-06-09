using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarLightPulse : MonoBehaviour
{
    private Light myLight;
    public float maxIntensity = 1f;
    public float minIntensity = 0f;
    public float maxRange = 1f;
    public float minRange = 0f;
    public float pulseSpeed = 1f; 

    private float targetIntensity;
    private float targetRange;

    private float currentIntensity;
    private float currentRange;


    void Start()
    {
        myLight = GetComponent<Light>();
        targetIntensity = maxIntensity;
        targetRange = maxRange;
    }
    void Update()
    {
        currentIntensity = Mathf.MoveTowards(myLight.intensity, targetIntensity, Time.deltaTime * pulseSpeed);
        currentRange = Mathf.MoveTowards(myLight.range, targetRange, Time.deltaTime * pulseSpeed);

        if (currentIntensity >= maxIntensity)
        {
            currentIntensity = maxIntensity;
            targetIntensity = minIntensity;
        }
        else if (currentIntensity <= minIntensity)
        {
            currentIntensity = minIntensity;
            targetIntensity = maxIntensity;
        }
        myLight.intensity = currentIntensity;

        if (currentRange >= maxRange)
        {
            currentRange = maxRange;
            targetRange = minRange;
        }
        else if (currentRange <= minRange)
        {
            currentRange = minRange;
            targetRange = minRange;
        }
        myLight.range = currentRange;
    }
}
