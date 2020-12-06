using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private AudioSource mAudioSrc;
    public GameObject crosshair;
    bool isPaused;
    private void Start()
    {
        //Cursor.visible = false;
        mAudioSrc = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        transform.position = Input.mousePosition;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            //Cursor.visible = true;
            //crosshair.SetActive(false);
        }
        else
        {
            //Cursor.visible = false;
           // crosshair.SetActive(true);
        }
    }
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            mAudioSrc.Play();
        }
        
    }
}
