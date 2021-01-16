using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public int startingHealth;
    public int currentHealth;
    public bool isAlive;
    NavMeshAgent Agent;
    public Animator animator;
    public Slider slider;
    public Image fillImage;

    void Start()
    {
        isAlive = true;
        startingHealth = 220;
        currentHealth = startingHealth;
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        if (currentHealth <= 50)
        {
            BossMov.Enraged = true;
        }
        if (currentHealth <= 0)
        {
            /*    if (isAlive)
                {
                    return;

                }
                else
                {*/
            if (isAlive) { 
                Agent.enabled = false;
            GetComponent<BossMov>().enabled = false;
            animator.SetFloat("speed", -5);
            StartCoroutine(DeathAnim());
            
                    }
            else
            {
                Destroy(gameObject);
            }

            


        }
    }
    public void HurtBoss(int damage)
    {
        
        currentHealth -= damage;
    }
    IEnumerator DeathAnim()
    {
        
        yield return new WaitForSeconds(2.6f);
        isAlive = false;
    }


}
