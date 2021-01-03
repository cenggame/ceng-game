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
    bool isWaiting=false;

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
        Debug.Log(isWaiting);

         if ( (EnemyHealthManager.score/10) >= (enemySpawnAmount + (scc) ) )
        {
            
            if(isWaiting)
            {
                return;
            }
            else
            {
                StartCoroutine(NextWave());
            }

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
    
     IEnumerator NextWave()
    {
            isWaiting = true;
            scc = EnemyHealthManager.score / 10;
            waveNumber++;
            yield return new WaitForSeconds(3f);
            enemySpawnAmount += 2;
            enemiesKilled = 0;
            for (int i = 0; i < enemySpawnAmount; i++)
            {
                SpawnEnemy();
            }

        isWaiting = false;
    }

  




}
