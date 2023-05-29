using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static int Score;
    public Text ShowScore;
    public static string[] lines_test;

    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score Update");
        ShowScore.text = "Score: " + Score.ToString();
        
    }
}
