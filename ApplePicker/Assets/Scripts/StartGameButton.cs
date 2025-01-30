using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Click Start Game button to start the game
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }

}
