using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    NavMeshAgent Agent;
    public float distance;
    GameObject target;
    public bool isLanding = true;
    Animator animator;
    public bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();


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

            Agent.SetDestination(target.transform.position);
            if (!isWalking)
            {
                animator.SetFloat("speed", 1);
                isWalking = true;
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
}
