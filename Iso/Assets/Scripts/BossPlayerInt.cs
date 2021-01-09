using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPlayerInt : MonoBehaviour
{
    //public Animator _anim;
    public int damageToGive;
    public float cooldownTime = 1;
    public float nextFireTime = 0;
    public bool isAttacking;
    public Animator animator;
    NavMeshAgent Agent;
    Component bosmov;
    public bool isEnraged;
    

    private void Start()
    {
        damageToGive = 4;
        animator = GetComponentInParent<Animator>();
        isAttacking = false;
        Agent = GetComponentInParent<NavMeshAgent>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        isEnraged = BossMov.Enraged;
        if (other.gameObject.CompareTag("Player")) { 
        
            if (isAttacking)
            {
                return;
            }
            else
            {
                
                StartCoroutine(Attack(other));



            }
        }

    }

    IEnumerator Attack(Collider other)
    {
        transform.parent.gameObject.GetComponent<BossMov>().isWalking = false;
        Agent.enabled = false;
        isAttacking = true;
        transform.parent.gameObject.GetComponent<BossMov>().isRunning = false;
        animator.SetFloat("speed", 6);
        yield return new WaitForSeconds(2);
        other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
        Agent.enabled = true;
        transform.parent.gameObject.GetComponent<BossMov>().isWalking = true;
        transform.parent.gameObject.GetComponent<BossMov>().isRunning = true;
        isAttacking = false;

    }
}





