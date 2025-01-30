    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManagerScript : MonoBehaviour
{

    public TextMeshProUGUI finalScoreText; // Assign in inspector

    // Start is called before the first frame update
    void Start()
    {
        // Get the final score from PlayerPrefs and update the text
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + finalScore;
    }

    // Option to play the game again
    public void PlayAgain()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
