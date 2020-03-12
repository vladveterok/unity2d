using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    
    GameStatus myGameStatus;
    TextMeshProUGUI scoreScreen;

    
    // Start is called before the first frame update
    void Start()
    {
        myGameStatus = FindObjectOfType<GameStatus>();
        scoreScreen = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreScreen.text = myGameStatus.GetScore().ToString();
    }
}
