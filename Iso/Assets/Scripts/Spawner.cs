using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public  int enemiesKilled = 0;
    public GameObject[] spawners;
    public GameObject enemy;
    int scc;
    bool isSpawned=false;
    static float a = 2;

    EnemyHealthManager en;

    private void Start()
    {
        spawners = new GameObject[10];

        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        StartWave();
    }

    private void Update()
    {
        Debug.Log(EnemyHealthManager.score);


        if ((EnemyHealthManager.score / 10) == 2)
        {
            if (!isSpawned)
            {
                if ((EnemyHealthManager.score / 10) >= enemySpawnAmount)
                {
                    isSpawned = true;
                    NextWave();
                }
            }
        }

        if ( (EnemyHealthManager.score/10) >= (enemySpawnAmount + (scc) ) )
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
        

        for (int i=0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
    
    public void NextWave()
    {

        
        scc=EnemyHealthManager.score/10;
        waveNumber++;
        enemySpawnAmount += 2;
        enemiesKilled = 0;
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
}
