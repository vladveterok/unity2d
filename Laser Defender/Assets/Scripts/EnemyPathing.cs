using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Config parameters
    WaveConfig waveConfig;
    List<Transform> waypoints;
    
    int waypointIndex = 0;
    float speed;
  

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].transform.position;
        speed = waveConfig.GetEnemySpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)

        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition) // Without IF -- round per frame
            {
                waypointIndex++;
                //Debug.Log("Round " + waypointIndex + "time: " + Time.time + "frame: " + Time.frameCount); // Debug info
            }
        }
        else Destroy(gameObject);
    }
}
