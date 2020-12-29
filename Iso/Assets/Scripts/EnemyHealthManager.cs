using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject hurtZone;
    CapsuleCollider capsule;
    public AudioSource mAudioSrc;
    public int health;
    private int currentHealth;
    public bool isDead = false;
    public int damage = 2;
    PlayerHealthManager crHealth;



    public static  int score;
    int scoreValue = 10;
    public int gainedHealth = 5;
    public Text scoreText;

    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        mAudioSrc = GetComponent<AudioSource>();
        currentHealth = health;
        mAudioSrc.Play();
        damage = 2;
        score = 0;
    }
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        if (currentHealth <= 0)
        {
            
            if (!isDead)
            {
                
                ScoreUpdate();
                gameObject.GetComponent<EnemyController>().die();
                isDead = true;
                mAudioSrc.Stop();
                capsule.enabled = false;
                damage = 0;
                hurtZone.SetActive(false);
            }
            else
                damage = 2;
        }
    }
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    public void ScoreUpdate()
    {
        score += scoreValue;

        //If score is multiple of 100, player will gain some health 
        if (score != 0 && score % 100 == 0)
        {
           // crHealth.currentHealth += gainedHealth;
        }
    }
}
