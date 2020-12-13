using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public float cooldownTime = 1;
    public float nextFireTime = 0;


    void OnTriggerStay(Collider other)
    {
        if (Time.time >nextFireTime)
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            nextFireTime = Time.time + cooldownTime;
        }
    }
    
}

