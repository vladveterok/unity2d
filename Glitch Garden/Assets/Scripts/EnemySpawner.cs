using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] float minSpawnRate = 1f; [SerializeField] float maxSpawnRate = 5f;
    bool isSpawn = true;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {   
        do
        {
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
            SpawnEnemies();
        } while (isSpawn);
    }

    private void SpawnEnemies()
    {
        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as Enemy;
        newEnemy.transform.parent = transform;
    } 
}
