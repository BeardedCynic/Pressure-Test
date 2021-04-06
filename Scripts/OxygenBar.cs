using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{

    [SerializeField] float maxOxygen;
    private float curOxygen = 0f;
    public Slider slider;
    
    
    void Start()
    {
        curOxygen = slider.value;
        SetOxygenBar();
    }
    private void SetOxygen(float pOxygen)
    {
        slider.value = pOxygen;
    }
    private void SetOxygenBar()
    {
        float myOxygen = curOxygen / maxOxygen;
        SetOxygen(myOxygen);
    }
    public void ModifyOxygen(float pOxygen)
    {
        if (curOxygen > maxOxygen)
        {
            curOxygen = maxOxygen;
            return;
        }

        if (GetComponent<OxygenMiniGameManager>().firstChallengeActive)
        {
            curOxygen += pOxygen;
            SetOxygen(curOxygen);
        }

        if (curOxygen <= 0)
        {
            curOxygen = 0;
            return;
        }
    }
}
