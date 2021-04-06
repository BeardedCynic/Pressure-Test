using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialMiniGameManager : MonoBehaviour
{
    public bool secondChallengeActive = false;
    private bool dialChallengeActive = false;
    private int randomTargetValue;
    public int thisCurrentValue;
    [SerializeField] Text targetValueTxt;
    [SerializeField] Text curValueTxt;
    [SerializeField] GameObject MiniGames;
    [SerializeField] GameObject GameMnger;
    [SerializeField] GameObject dialSlider;
    [SerializeField] GameObject dialParent;
    [SerializeField] GameObject ChamberDoor;
 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        thisCurrentValue = Convert.ToInt32(curValueTxt.text);
    }

    void DialChallenge()
    {
        if (dialChallengeActive == true)
        {
            randomTargetValue = UnityEngine.Random.Range(10, 90);
            targetValueTxt.text = randomTargetValue.ToString();
            return;
        }
        else if (dialChallengeActive == false)
        {
            if (thisCurrentValue == randomTargetValue)
            {
                Debug.Log("Dial Challenge Complete");

                GameMnger.GetComponent<AgentManager>().GoToDeath();
                var toZero = 0;
                targetValueTxt.text = toZero.ToString();
                MiniGames.SetActive(false);
                GameMnger.GetComponent<ScoreCounter>().ScoreMod(200);
                dialSlider.transform.rotation = Quaternion.Euler(0,0,0);
                dialParent.GetComponent<DialSlider>().valTxt.text = toZero.ToString();
                dialParent.GetComponent<DialSlider>().fill.fillAmount = 0;
                ChamberDoor.SetActive(false);
            }
            else
            {
                DialChallengeToggle();
                Debug.Log("Fail - Restart Dial Challenge");
            }
        }

    }

    public void DialChallengeToggle()
    {
        if (secondChallengeActive)
        {
            dialChallengeActive = !dialChallengeActive;
            DialChallenge();
        }
    }

    public void SecondChallengeEnter()
    {
        secondChallengeActive = true;
        DialChallengeToggle();
    }
}
