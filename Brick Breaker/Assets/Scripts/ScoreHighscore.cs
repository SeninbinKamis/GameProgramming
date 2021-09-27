using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHighscore : MonoBehaviour
{
    public static int score;
    public static int highscore;
    Text highscorePoint;
    // Start is called before the first frame update
    void Start()
    {
        highscorePoint = GameObject.Find("HighcorePoint").GetComponent<Text>();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            highscorePoint.text = "" + score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
    public static void AddPoints (int pointsToAdd)
    {
        score += pointsToAdd;
    }
    public static void Reset()
    {
        score = 0;
    }
}
