using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    [SerializeField] WaveConfig waveConfig;

    int scoreValue = 5;

    //saves the waypoint in which we want to go
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();

        //set the start position of Enemy to the first waypoint.
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();   
    }

    private void enemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        { 
            //set the targetPosition to the waypoint where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //make sure the z-axis is 0
            targetPosition.z = 0f;

            var enemyMovement = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            //move Enemy from current position to targetPosition, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            //if enemy reaches the target position
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

            Destroy(gameObject);
        }
    }

    //set a WaveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
