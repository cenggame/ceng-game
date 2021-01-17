using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public int startingHealth;
    public int currentHealth;
    public bool isAlive;
    NavMeshAgent Agent;
    public Animator animator;
    public Slider slider;
    public Image fillImage;
    public GameObject winMenu;
    bool isDead = false;

    void Start()
    {
        isAlive = true;
        startingHealth = 500;
        currentHealth = startingHealth;
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Cursor.visible = true;
        }
        slider.value = currentHealth;
        if (currentHealth <= startingHealth / 2)
        {
            BossMov.Enraged = true;
        }
        if (currentHealth <= 0)
        {
            if (isAlive) {
                Agent.enabled = false;
                GetComponent<BossMov>().enabled = false;
                animator.SetFloat("speed", -5);
                StartCoroutine(DeathAnim());
            }
            else
            {

                //Destroy(gameObject);
            }

        }


        if (isDead)
        {
            
            winMenu.SetActive(true);
            slider.gameObject.SetActive(false);

            Cursor.visible = true;
            //Destroy(gameObject);
        }
    }
    public void HurtBoss(int damage)
    {
        
        currentHealth -= damage;
    }
    IEnumerator DeathAnim()
    {
        yield return new WaitForSeconds(2.6f);
        isAlive = false;
        isDead = true;
    }
    IEnumerator EndGame()
    {
        this.GetComponent<Final_char_cont>().enabled = false;
        yield return new WaitForSeconds(3f);
        fillImage.enabled = false;
        //winMenu.SetActive(true);
        Time.timeScale = 0;

    }

}
