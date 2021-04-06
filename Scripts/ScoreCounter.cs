using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int curScore = 0;
    [SerializeField] Text ScoreText;

    private void Start()
    {
        curScore = 0;
        ScoreText.text = "Score: " + curScore.ToString();
    }

    public void ScoreMod(int modScoreValue)
    {
        curScore += modScoreValue;
        ScoreText.text = "Score: " + curScore.ToString();
        PlayerPrefs.SetInt("PlayerScore", curScore);
    }
}
