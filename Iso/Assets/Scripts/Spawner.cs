using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public  int enemiesKilled = 0;
    public GameObject[] spawners;
    public GameObject enemy;
    int scc;
    bool isWaiting = false;
    bool isStarting = true;
    public Text waveStatus;


    private void Awake()
    {
        enemySpawnAmount = 0;
        waveNumber = 0;
    }
    private void Start()
    {
        spawners = new GameObject[10];

        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        if(isStarting)
        {
            StartCoroutine(Starting());
        }
        else
        {
            StartWave();
        }
    }

    private void Update()
    {

         if ((EnemyHealthManager.score/10) >= (enemySpawnAmount + (scc)))
        {
            
            if(isWaiting)
            {
                return;
            }
            else if(isStarting)
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
        waveStatus = GameObject.Find("Wave Status").GetComponentInChildren<Text>();
        waveStatus.text = "Wave  " + waveNumber;
        enemySpawnAmount = 2;
        enemiesKilled = 0;

        for (int i=0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
    
     IEnumerator NextWave()
    {
        waveStatus.text = "Get ready for the next wave!";
        isWaiting = true;
        scc = EnemyHealthManager.score / 10;
        waveNumber++;
        yield return new WaitForSeconds(5f);
        enemySpawnAmount += 2;
        enemiesKilled = 0;
        for (int i = 0; i < enemySpawnAmount; i++)
            {
                SpawnEnemy();
            }
        waveStatus.text = "Wave : "+waveNumber;

        isWaiting = false;
    }

    IEnumerator Starting()
    {
        waveStatus.text = "Get Ready!";
        yield return new WaitForSeconds(2f);
        waveStatus.text = "Equip Your Weapon!";
        yield return new WaitForSeconds(2f);
        waveStatus.text = "Save Your Campus!";
        yield return new WaitForSeconds(2f);

        isStarting = false;
    }

  




}
