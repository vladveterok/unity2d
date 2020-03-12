using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    //Config params
    [Header("Enemy")]
    [SerializeField] AudioClip enemyDestroyedSound;
    [Range(0f, 1f)] [SerializeField] float enemyDestroyVolume;
    [SerializeField] AudioClip enemyShootingSound;
    [Range(0f, 1f)] [SerializeField] float enemyShotVolume;
    [Header("Player")]
    [SerializeField] AudioClip playerDestroyedSound;
    [Range(0f, 1f)] [SerializeField] float playerDestroyVolume;
    [SerializeField] AudioClip playerShootingSound;
    [Range(0f, 1f)] [SerializeField] float playerShotVolume;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1) //GetType method returnes the type that THIS class is;
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else DontDestroyOnLoad(gameObject);
    }

    public void PlayOnEnemyDestroyed()
    {
        AudioSource.PlayClipAtPoint(enemyDestroyedSound, Camera.main.transform.position, enemyDestroyVolume);
    }
 
    public void PlayOnEnemyShooting()
    {
        GetComponent<AudioSource>().PlayOneShot(enemyShootingSound, enemyShotVolume);
    }

    public void PlayOnPlayerDestroyed()
    {
        AudioSource.PlayClipAtPoint(playerDestroyedSound, Camera.main.transform.position, playerDestroyVolume);
    }

    public void PlayOnPlayerShooting()
    {
        GetComponent<AudioSource>().PlayOneShot(playerShootingSound, playerShotVolume);
    }
    
}
