using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public static int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
        PlayerPrefs.SetInt("PlayerScore", 0);

        scoreText.text = "Score: " + score;
    }
}
