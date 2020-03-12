using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float gameOverDelay = 2;


    public void LoadNextScene()
    {   
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(GameOver(gameOverDelay));
        IEnumerator GameOver(float gameOverDelay)
        {
            yield return new WaitForSeconds(gameOverDelay);
            SceneManager.LoadScene("Game Over Scene");   
        }  
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quit");
    }
}
