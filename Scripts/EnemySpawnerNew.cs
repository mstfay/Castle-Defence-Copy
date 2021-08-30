using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerNew : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    [SerializeField] public int numberOfEnemies2 = 0;

    [Header("Enemy OLD")]
    [SerializeField] GameObject enemiesPrefab;
    [SerializeField] float passingTime = 0;
    [SerializeField] float spawnTime = 3;
    [SerializeField] int round = 0;
    [SerializeField] int maxRound = 4;
    [SerializeField] public int numberOfEnemies = 5;
    float min = -8.0f;
    float max = 2f;

    IEnumerator Start()
    {        
        do
        {
            yield return StartCoroutine(SpawnsAllWawe());
        }
        while (looping);
    }

    void Update()
    {
        passingTime += Time.deltaTime;
        if (maxRound >= round)
        {
            if (passingTime >= spawnTime)
            {
                SpawnEnemies();
            }
        }
    }

    void SpawnEnemies()
    {
        Vector2 position = new Vector2();
        position.x = -17.0f;
        position.y = Random.Range(min, max);
        GameObject enemies = Instantiate(enemiesPrefab, position, Quaternion.identity);
        passingTime = 0;
        round++;
           
    }

    public void Enemies()
    {
        numberOfEnemies--;
        Debug.Log(numberOfEnemies);
    }

    IEnumerator SpawnsAllWawe()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            numberOfEnemies2++;
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }        
    }
}
