using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Inspectorda serializefield' ı görebilmek adına yazdık.
/// </summary>
[System.Serializable]
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;    
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public Animator animator;
    public Text waveName; 

    Wave currentWave;
    int currentWaveNumber;
    float nextSpawnTime;
    bool canSpawn = true;
    bool canAnimate = false;
    Level level;
    int buildIndex;
    public int yRotation = 0;
    //float waitTime = 2f;

    void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        level = FindObjectOfType<Level>();
    }

    void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimate)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    animator.SetTrigger("WaveComplete");
                    canAnimate = false;
                }                
            }
            else
            {
                LevelBitti();
            }
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    /// <summary>
    /// 34 - randomEnemy oyun objesi oluşuruldu. Mevcut wave' in düşman tipi sayısı kadar düşmanı rastgele spawn ediyor.
    /// 35 - Inspectorda belirlediğimiz rastgele spawn noktalarından birini randompoint kordinatına atıyor.
    /// </summary>
    void SpawnWave()
    {
        if (WallProperties.isActive == true)
        {
            if (canSpawn && nextSpawnTime < Time.time)
            {
                GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomPoint.position, Quaternion.Euler(0, yRotation, 0));
                currentWave.numberOfEnemies--;
                nextSpawnTime = Time.time + currentWave.spawnInterval;
                if (currentWave.numberOfEnemies == 0)
                {
                    canSpawn = false;
                    canAnimate = true;
                }
            }
        }         
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public void LevelBitti()
    {
        if (buildIndex > PlayerPrefs.GetInt("SaveIndex"))
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }        
        level.CompleteLevel();
        ResetGame();
    }
}
