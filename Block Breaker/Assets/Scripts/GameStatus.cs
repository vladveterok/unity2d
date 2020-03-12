using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed =1f;
    [SerializeField] TextMeshProUGUI scoreScreen;
    [SerializeField] int pointsPerBlock = 50;
    [SerializeField] int score; //Serialized for Debuging
    [SerializeField] bool isAutoPlaying;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject); // try Destroy(this);
        } else 
        {
            DontDestroyOnLoad(gameObject);
        }
    } 


    // Start is called before the first frame update
    void Start()
    {
        if (isAutoPlaying)
        {
            IsAutoPlayEnabled();
        }
        
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        score += pointsPerBlock;
        scoreScreen.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
