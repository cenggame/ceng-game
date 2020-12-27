using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource au;
   

    void Start()
    {
        cc = GetComponent<CharacterController>();
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
