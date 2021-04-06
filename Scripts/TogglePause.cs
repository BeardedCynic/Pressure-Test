using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePause : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    private void Start()
    {
        PauseScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseScreen.activeInHierarchy)
            {
                PauseGame();
            }
            else if (PauseScreen.activeInHierarchy)
            {
                ContinueGame();
            }
        }

    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }
}