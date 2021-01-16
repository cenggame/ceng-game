using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour
{
    public CapsuleCollider capsule;
    public GameObject game_Over;
    Animator _animator;
    public int startingHealth;
    public int currentHealth;
    public Slider slider;
    public Image fillImage;
    public  bool isDead=false;
    public bool isDying = false;
    public float waitTime=3f;
    public bool gameOverMenu;
    public PauseMenu pauseMenu;
    public Text scoreText;


    void Start()
    {
        currentHealth = startingHealth;
        _animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        scoreText = GameObject.Find("ScoreValue").GetComponentInChildren<Text>();
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
                if(isDying)
                {
                    return;
                }
                else
                {
                    StartCoroutine(PlayerDie());
                    
                }
            }
        }
        if (gameOverMenu)
        {
            game_Over.SetActive(true);

            if (SceneManager.GetActiveScene().name == "SampleScene") {
                scoreText.text = "" + EnemyHealthManager.score;
            }
            else
            {
                int score = EnemyHealthManager.score + Spawner.level1Score;
                scoreText.text = "" + score;
            }   
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
    IEnumerator PlayerDie()
    {
        this.GetComponent<Final_char_cont>().enabled = false;
        isDying = true;
        isDead = true;
        _animator.SetTrigger("death");
        yield return new WaitForSeconds(3f);
        fillImage.enabled = false;
        gameOverMenu = true;
        isDying = false;
    }
    public void MainMenu()
    {
        game_Over.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        EnemyHealthManager.score = 0;
    }
}
