using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject crosshair;
    bool isPaused;
    private void Start()
    {
       //Cursor.visible = false;
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
}
