using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenMiniGameManager : MonoBehaviour
{
    private bool oxygenChallengeActive = false;
    private int randomOxygenValue;
    private int randomTargetValue;
    public Slider targetOxygenSlider;
    private float lowerSliderValue;
    private float higherSliderValue;
    public bool firstChallengeActive = false;
    private float currentSliderValue;

    private void OnEnable()
    {
        firstChallengeActive = true;
        OxygenChallengeToggle();
    }

    void OxygenChallenge()
    {
        if (oxygenChallengeActive)
        {
            randomTargetValue = Random.Range(200, 800);
            targetOxygenSlider.value = randomTargetValue;
            StartCoroutine("OxygenVariance");
            randomOxygenValue = Random.Range(5, 50);
        }
        else if (!oxygenChallengeActive)
        {
            StopCoroutine("OxygenVariance");

            //Setting an upper and lower limit for the acceptable range of results based on the current value
            currentSliderValue = GetComponent<OxygenBar>().slider.value;
            higherSliderValue = (currentSliderValue + 50);
            lowerSliderValue = (currentSliderValue - 50);

            //Using .CompareTo to check if the target value is within the range that I built above
            if (lowerSliderValue.CompareTo(randomTargetValue) <= 0 & higherSliderValue.CompareTo(randomTargetValue) >=0)
            {
                firstChallengeActive = false;
                GetComponent<DialMiniGameManager>().SecondChallengeEnter();
                Debug.Log("Transition to Challenge 2");
            }
            else
            {
                OxygenChallengeToggle();
            }
            //If the target value is not within the range, I run the OxygenChallengeToggle again to set a new Target and start the minigame over
        }
    }

    public void OxygenChallengeToggle()
    {
        if (firstChallengeActive)
        {
            oxygenChallengeActive = !oxygenChallengeActive;
            OxygenChallenge();
        }
    }

    IEnumerator OxygenVariance()
    {
        while (true)
        {
            Debug.Log("Coroutine Start");
            yield return new WaitForSeconds(1f);
            GetComponent<OxygenBar>().ModifyOxygen(randomOxygenValue);
        }
    }
}
