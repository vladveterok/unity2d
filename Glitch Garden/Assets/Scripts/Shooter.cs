using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    EnemySpawner myLaneSpawner;
    
    void Start()
    {
        SetLaneSpawner();
    }
    void Update()
    {
        if(IsAttackerInLane())
        {
            Debug.Log("shoot pew pew");
            //Change animation state to shooting
        }
        else
        {
            Debug.Log("Sit and wait");
            //Change animation state to idle
        }
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner spawner in enemySpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        //if my lane spawner child count is less than or equal to 0
        // return false
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        } else return true;
    }


   public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
