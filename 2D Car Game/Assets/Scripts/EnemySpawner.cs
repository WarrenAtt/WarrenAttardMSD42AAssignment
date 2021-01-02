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
        //set the current wave to Wave 1 [position 0 in List]
        var currentWave = waveConfigList[startingWave];

        //Start coroutine that spawns all enimies in currentWave
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when calling Coroutine, specify which Wave we need to spawn enemies from
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        //spawn the enemy from waveConfig at the position specified by waveConfig waypoints
        Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
        //wait timeBetweenSpawns before spawning another enemy
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
    }
}
