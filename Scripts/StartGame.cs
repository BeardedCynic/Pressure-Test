using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject Gamemnger;
    [SerializeField] GameObject MainCanvas;

    private void Start()
    {
        StartPanel.SetActive(true);
    }
    public void ExecuteOrder66()
    {
        StartPanel.SetActive(false);
        Gamemnger.GetComponent<AgentManager>().GoToChamber();
        MainCanvas.GetComponent<Timer>().timerIsRunning = true;
        Time.timeScale = 0f;
        Time.timeScale = 1;
    }
}
