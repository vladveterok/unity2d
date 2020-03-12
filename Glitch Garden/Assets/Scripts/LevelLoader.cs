using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float loadingTime = 3;

    int currentSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene # " + currentSceneIndex);
        if(currentSceneIndex == 0)
        {
        LoadStartScene();
        }
    }

    private void LoadStartScene()
    {
        StartCoroutine(LoadStartAfterPause(loadingTime));
        IEnumerator LoadStartAfterPause(float loadingTime)
        {
            yield return new WaitForSeconds(loadingTime);
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 2); // It's not right!!!!!!!!!!!!!!!!!! Why 2? Should be 1.
    }

   public void QuitGame()
   {
       Application.Quit();
   }
}
