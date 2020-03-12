using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject enemyDeathVFX;

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            
        }
    }

    private void TriggerDeathVFX()
    {
        if(!enemyDeathVFX) {return;}
        GameObject deathVFX = Instantiate(enemyDeathVFX, transform.position, transform.rotation);
        Destroy(deathVFX, 1f);
    }
}
