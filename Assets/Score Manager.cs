using TMPro;
using UnityEngine;

static public class ScoreManager
{
    static public TextMeshProUGUI text;
    static public TextMeshProUGUI HighScoreText;

    static public int sessionScore = -1;

    static public void SwitchScene()
    {
        text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        HighScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<TextMeshProUGUI>();
        text.text = sessionScore.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("highscore").ToString();
    }
    static public void FinishGame()
    {
        text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        HighScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<TextMeshProUGUI>();
        text.text = sessionScore.ToString();
        HighScoreText.text = "HighScoer\n" + PlayerPrefs.GetInt("highscore").ToString();
        if (sessionScore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", ScoreManager.sessionScore);
            sessionScore = -1;
            HighScoreText.text = "New Highscore\n" + PlayerPrefs.GetInt("highscore").ToString();
        }
    }
}
