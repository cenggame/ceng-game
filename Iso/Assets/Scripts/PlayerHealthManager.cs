using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public CapsuleCollider capsule;
    public GameObject game_Over;
    Animator _animator;
    public int startingHealth;
    public int currentHealth;
    public Slider slider;
    public Image fillImage;
    public bool isDead=false;
    public float waitTime=5f;
    public bool gameOverMenu;
    public float lifeTime = 3f;

    void Start()
    {
        currentHealth = startingHealth;
        _animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

       
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {
            //capsule.enabled = false;
            if (!isDead)
            {
                PlayerDie();
                fillImage.enabled = false;
                isDead = true;
                gameOverMenu = true;
            }

        }
        if(gameOverMenu)
        {
            game_Over.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            
        }
        else
        {
            game_Over.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
    }
    void PlayerDie()
    {
        _animator.SetTrigger("death");

    }
    public void MainMenu()
    {
        game_Over.SetActiveRecursively(false);
        SceneManager.LoadScene("Menu");
    }
    
    
    public void QuitGame()
    {
        Application.Quit();

    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
