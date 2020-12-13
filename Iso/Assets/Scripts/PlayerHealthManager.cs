using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public Slider slider;
    public Image fillImage;
   // public float flashLength;
   // private float flashCounter;

   // private Renderer rend;
   //private Color storedColor;

    void Start()
    {
        currentHealth = startingHealth;

        
        //rend = GetComponent<Renderer>();
       // storedColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            fillImage.enabled = false;
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        //flashCounter = flashLength;
        //rend.material.SetColor("_Color", Color.red);
    }
}
