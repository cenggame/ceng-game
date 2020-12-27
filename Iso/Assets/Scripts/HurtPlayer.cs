using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    //public Animator _anim;
    public int damageToGive;
    public float cooldownTime = 1;
    public float nextFireTime = 0;

    private void Start()
    {
        //_anim = GetComponent<Animator>();
    }
    void OnTriggerStay(Collider other)
    {
       // isDead = GetComponent<EnemyHealthManager>().isDead;
        if (Time.time >nextFireTime)
        {
            if (damageToGive != 0)
            {
               // gameObject.GetComponent<EnemyController>().attack();
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
                nextFireTime = Time.time + cooldownTime;
            }
            
        }
    }
    
    


}

