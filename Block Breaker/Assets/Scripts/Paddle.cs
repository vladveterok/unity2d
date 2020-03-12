using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parametrs
    [SerializeField] float screenUnitsX;
    [SerializeField] float leftScreenBoarder;
    [SerializeField] float rightScreenBoarder;

    // Cached References
    GameStatus gameStatus;
    Ball ball;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPosition(), leftScreenBoarder, rightScreenBoarder);
        transform.position = paddlePosition;
    }

    private float GetXPosition()
    {
        if(gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        } 
        else
        {
            return Input.mousePosition.x / Screen.width * screenUnitsX;
        }
    }

   
}
