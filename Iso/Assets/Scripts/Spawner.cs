using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    EnemyHealthManager en;
    public int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public int enemiesKilled = 0;

    public GameObject[] spawners;
    public GameObject enemy;

    private void Start()
    {
       // en = GetComponent<EnemyHealthManager>();
        spawners = new GameObject[10];

        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        StartWave();
    }

    private void Update()
    {
        enemiesKilled = GetComponent<EnemyHealthManager>().enemiesKilled;
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnEnemy();
        }

        if (enemiesKilled >= enemySpawnAmount)
        {
            NextWave();
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    public void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmount = 2;
        enemiesKilled = 0;

        for(int i=0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
    
    public void NextWave()
    {
        waveNumber++;
        enemySpawnAmount += 2;
        enemiesKilled = 0;
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
}
