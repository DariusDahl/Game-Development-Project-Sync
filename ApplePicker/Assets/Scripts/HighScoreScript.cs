using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI; // We need this line for uGUI to work
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreScript : MonoBehaviour
{

    static private TextMeshProUGUI _UI_Text;
    static private int _SCORE = 1000;
    private TextMeshProUGUI txtCom; // txtCom is a reference to this GO's TextMeshProUGUI component

    void Awake() {
        _UI_Text = GetComponent<TextMeshProUGUI>();

        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE {
        get {
            return _SCORE;
        }

        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_Text != null) {
                _UI_Text.text = "High Score: " + value.ToString();
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) {
            return;
        }
        SCORE = scoreToTry;
    }

    // The following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore has been reset to 1000");
        }
    }

    void GameOver()
    {
        // Save the final score before switching scenes
        PlayerPrefs.SetInt("FinalScore", SCORE);
        PlayerPrefs.Save();

        // Load the Game Over screen
        SceneManager.LoadScene("GameOverScreen");
    }

}
