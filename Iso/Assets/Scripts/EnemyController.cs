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
    // Start is called before the first frame update
    void Start()
    {
        ZombieAnim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ZombieAnim.SetFloat("speed",Agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position,Target.position);
        Agent.destination = Target.position;
        Agent.enabled = true;
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
}
