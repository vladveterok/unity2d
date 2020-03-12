using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class WaveConfig : ScriptableObject
{
    //Config parameters
[SerializeField] GameObject enemyPrefab;
[SerializeField] GameObject pathPrefab;
[SerializeField] float spawnRate;
[SerializeField] float randomSpawnFactor;
[SerializeField] int numberOfEnemies;
[SerializeField] float enemySpeed;

public GameObject GetEnemyPrefab() {return enemyPrefab;}
public List<Transform> GetWayPoints() 
{
    var waveWaypoints = new List<Transform>();
    foreach(Transform child in pathPrefab.transform)
    {
        waveWaypoints.Add(child);
    }
    return waveWaypoints;
}
public float GetSpawnRate(){return spawnRate;}
public float GetRandomSpawnFactor(){return randomSpawnFactor;}
public int GetNumberOfEnemies(){return numberOfEnemies;}
public float GetEnemySpeed(){return enemySpeed;}
}



