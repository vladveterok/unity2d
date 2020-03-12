using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStatus : MonoBehaviour
{
    // Config Params
    [Range(0f, 1f)][SerializeField] float gameSpeed;

    // Cached references
    int score;
    
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int gameStatussCount = FindObjectsOfType<GameStatus>().Length;
        
        if(gameStatussCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public int GetScore()
    {
        return score;
    }
    
    public void AddToScore(int pointsPerKill)
    {
        score += pointsPerKill;

    }
    public void ResetGame()
    {
        Destroy(gameObject);
        score = 0;
    }
}
