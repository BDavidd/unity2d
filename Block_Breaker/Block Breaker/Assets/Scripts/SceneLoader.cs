using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameSession gameSession;
    
    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex > (SceneManager.sceneCountInBuildSettings - 1))
        {
            nextSceneIndex = 0;
            gameSession.ResetScore();
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
