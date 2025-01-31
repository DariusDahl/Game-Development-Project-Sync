using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePickerScript : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    private ScoreCounterScript scoreCounter; // Reference to ScoreCounterScript


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        // Find ScoreCounterScript in the scene
        GameObject scoreCounterGO = GameObject.Find("ScoreCounter");
        if (scoreCounterGO != null)
        {
            scoreCounter = scoreCounterGO.GetComponent<ScoreCounterScript>();
        }
        else
        {
            Debug.LogError("ScoreCounter GameObject not found in the scene.");
        }
    }

    public void AppleMissed()
    {
        // Destory all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] goldenAppleArray = GameObject.FindGameObjectsWithTag("GoldenApple");

        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        foreach (GameObject tempGO in goldenAppleArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // If there are no more Baskets left, restart the game
        if (basketList.Count == 0)
        {
            if (scoreCounter != null)
            {
                HighScoreScript.TRY_SET_HIGH_SCORE(scoreCounter.score); // Save high score
                PlayerPrefs.SetInt("FinalScore", scoreCounter.score);  // Save final score
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("GameOverScreen"); // Load Game Over Scene
        }
    }
}
