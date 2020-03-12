using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parametrs
    [SerializeField] Paddle paddle1;
    [SerializeField] float ballVelocityX;
    [SerializeField] float ballVelocityY;
    [SerializeField] AudioClip[] collisionSound;
    [SerializeField] float velocityRandomFactor = 0.2f;

    
    // state
    Vector2 paddleToBallVector;
    bool hasStarted;

    //Cached component references
    AudioClip audioClips;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            StartBallPosition();
            LaunchBallOnMouseClick();
        } 

       
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
    }

    private void StartBallPosition()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(-0.2f, velocityRandomFactor), 
            UnityEngine.Random.Range(0.0f, velocityRandomFactor));

        if(hasStarted)
        {
            audioClips = collisionSound[UnityEngine.Random.Range(0, collisionSound.Length)];
            myAudioSource.PlayOneShot(audioClips, 0.7f);
            myRigidBody2D.velocity += velocityTweak;
        }
        
    }


}
