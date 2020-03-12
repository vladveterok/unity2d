using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config parametrs
    [Header("Player")]
    [SerializeField] float playerHealth = 300;
    [SerializeField] float playersSpeed = 15f;
    [SerializeField] float padding = 0.5f;
    [Header("Projectile")]
    [SerializeField] GameObject laser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float fireRate = 0.2f;

    // Cached refs 
    float xMin, xMax;
    float yMin, yMax;
    float playersVectorX;  //Set a Player's X position into BackroundScroller class
    AudioHandler myAudioHandler;
    SceneLoader sceneLoader; //SCENE LOADER



    
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        myAudioHandler = FindObjectOfType<AudioHandler>();
        sceneLoader = FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>();  //Check if I need GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer){return;}
        HitAndDestroyPlayer(damageDealer);
    }

    private void HitAndDestroyPlayer(DamageDealer damageDealer)
    {
        playerHealth -=  damageDealer.GetDamage();
        damageDealer.DestroyObject();
       
        if (playerHealth <= 0)
        {
            myAudioHandler.PlayOnPlayerDestroyed();
            sceneLoader.LoadGameOverScene();
            Destroy(gameObject); 
        }
    }

    public float GetPlayersHealth()
    {
        return playerHealth;
    }

    private void Fire()
    {
         if(Input.GetButtonDown("Fire1"))
        {
            
            StartCoroutine(fireFrequency());
        }
    }

    IEnumerator fireFrequency()
    {
        //Debug.Log("Coroutin is started");
        while(Input.GetButton("Fire1"))
        {
            GameObject laserGameObject = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            laserGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            myAudioHandler.PlayOnPlayerShooting();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void SetUpMoveBoundaries()
    {
        // Assign main camera to variable Camera gameCamera
        Camera gameCamera = Camera.main;

        //Check what is the value for Main Camera vector points 0 and 1 on X in World Space with padding(half of a ship's size)
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;

        //Check what is the value for Main Camera vector points 0 and 1 on Y in World Space with padding(half of a ship's size)
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
    }

    private void Move()
    {
        // Movement on X with boundaries
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playersSpeed;
        var newXPos = Mathf.Clamp (transform.position.x + deltaX, xMin, xMax);
        // Movement on Y with boundaries
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playersSpeed;
        var newYPos = Mathf.Clamp (transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
        
        playersVectorX = deltaX; //Set a Player's X position into BackroundScroller class   
         
    }

    //Set a Player's X position into BackroundScroller class
    public float PlayersVectorX()
    {
        return playersVectorX;
    }

   
}
