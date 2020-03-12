using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    [SerializeField] int breakableBlocks; // Serialized for debuging, DO NOT CHANGE
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    
    public void DeductIfDestroid()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        sceneLoader.LoadNextScene();
    }
}
