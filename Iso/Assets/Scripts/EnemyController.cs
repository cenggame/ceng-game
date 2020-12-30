using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator ZombieAnim;
    public Transform Target;
    NavMeshAgent Agent;
    public float distance;
    GameObject target; 
    // Start is called before the first frame update
    void Start()
    {

        ZombieAnim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
         ZombieAnim.SetFloat("speed",Agent.velocity.magnitude);
        Agent.SetDestination(target.transform.position);
    }
    public void die()
    {
        Agent.speed = 0;
        Agent.enabled = false;
        ZombieAnim.SetTrigger("death");

    }
    public void attack()
    {
        ZombieAnim.SetTrigger("attack");
    }

    public void PlayerDie()
    {
       // Agent.speed = 0;
        //Agent.enabled = false;
        //this.enabled = false;
    }
}
