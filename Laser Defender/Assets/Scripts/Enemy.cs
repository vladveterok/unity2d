using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] float health;
    [SerializeField] int killValue;

    [Header("Projectile")]
    [SerializeField] GameObject laser;
    [SerializeField] float laserSpeed; [SerializeField] float minTimeBetweenShots = 0.2f; 
    [SerializeField] float maxTimeBetweenShots = 3f; 
    [SerializeField] bool notShoot = false;

    [Header("Death VFX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion;

    float shotCounter;
    AudioHandler myAudioHandler;
    GameStatus myGameStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        myAudioHandler = FindObjectOfType<AudioHandler>();
        myGameStatus = FindObjectOfType<GameStatus>();
        
    }  

     // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            myAudioHandler.PlayOnEnemyShooting(); //PLAY SHOOTING AUDIO
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        if(notShoot == false)
        {
            GameObject laserGameObject = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            laserGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer){return;}
        HitAndDestroyEnemy(damageDealer);
    }

    private void HitAndDestroyEnemy(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.DestroyObject();
        if (health <= 0) 
        {
            myAudioHandler.PlayOnEnemyDestroyed();
            Destroy(gameObject);
            GameObject enemyExplosion = Instantiate(deathVFX, transform.position, Quaternion.identity); 
            Destroy(enemyExplosion, durationOfExplosion);
            myGameStatus.AddToScore(killValue);
        }
    }

   

}
