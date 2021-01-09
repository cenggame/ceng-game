using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMov : MonoBehaviour
{
    NavMeshAgent Agent;
    public float distance;
    GameObject target;
    public bool isLanding = true;
    Animator animator;
    public bool isWalking;
    public static bool Enraged;
    public bool isRoaring;
    public bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        Enraged = false;
        isRoaring = true;
        isWalking = true;
        target = GameObject.FindGameObjectWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isRunning = true;
        
  
    }

    // Update is called once per frame
    void Update()
    {
                

            if (isLanding)
            {
            StartCoroutine(Landing());
            return;
               
            }
            else
            {
            if (!Enraged) { 
            
              Agent.SetDestination(target.transform.position);
              if (isWalking) {
                animator.SetFloat("speed", 1);
                
                }}
            if (Enraged)
            {
                if (isRoaring)
                {
                    animator.SetBool("isEnraged", true);
                    isWalking = false;
                    StartCoroutine(Roaring());
                    return;
                }
                
                if (isRunning)
                {
                    Agent.SetDestination(target.transform.position);
                    animator.SetFloat("speed", 3);
                }
                
                Agent.speed = 10;
               
                
            }
            }


            //distance = Vector3.Distance(transform.position,Target.position);
            //Agent.destination = target.transform.position;
            //Agent.enabled = true;
            
        //Agent.enabled = true;
    }
    IEnumerator Landing()
    {
        

        
        yield return new WaitForSeconds(6);

        isLanding = false;
    }
    IEnumerator Roaring()
    {   
        Agent.enabled = false;
        yield return new WaitForSeconds(5);
        Agent.enabled = true;
        isRoaring = false;
        
    }
}
