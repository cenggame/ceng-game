using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject hurtZone;
    CapsuleCollider capsule;
    private AudioSource mAudioSrc;
    public int health;
    private int currentHealth;
    public bool isDead = false;
    public int damage = 2;
    
    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
        mAudioSrc = GetComponent<AudioSource>();
        currentHealth = health;
        mAudioSrc.Play();
        damage = 2;
    }

    void Update()
    {
        
        if (currentHealth <= 0)
        {

            if (!isDead)
            {
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
}
