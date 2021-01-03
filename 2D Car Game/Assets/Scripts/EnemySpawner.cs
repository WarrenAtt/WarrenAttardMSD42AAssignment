using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigList;

    //start from Wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Start coroutine that spawns all enimies in currentWave
        StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //when calling Coroutine, specify which Wave we need to spawn enemies from
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        //loop to spawn enemies in wave
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnimies(); enemyCount++)
        {
            //spawn the enemy from waveConfig at the position specified by waveConfig waypoints
            var newEnemy = Instantiate(waveToSpawn.GetEnemyPrefab(), waveToSpawn.GetWaypoints()[0].transform.position, Quaternion.identity);

            //the wave will be selected from here and the enemy applied to it
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            //wait timeBetweenSpawns before spawning another enemy
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //loop all waves
        foreach(WaveConfig currentWave in waveConfigList)
        {
            //wait for all enimies to spawn before going to the next wave
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        } 
    }
}