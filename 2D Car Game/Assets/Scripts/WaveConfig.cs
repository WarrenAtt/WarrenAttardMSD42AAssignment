using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the enemy that will spawn in this wave
    [SerializeField] GameObject enemyPrefab;

    //this is the path that the wave will follow
    [SerializeField] GameObject pathPrefab;

    //time between each enemy Spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies in the wave
    [SerializeField] int numberOfEnemies = 5;

    //the speed of the enemy
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWaypoints = new List<Transform>();

        //access path prefab and for each waypoint
        //add it to the List waveWaypoints
        foreach(Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnimies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
