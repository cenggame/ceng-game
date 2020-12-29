using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public int score;
    int scoreValue = 10;
    int gainedHealth = 10;
    //public Text scoreText;

    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    //When the enemy is dead, score is updated
    
    /*public void ScoreUpdate()
    {
        score += scoreValue;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "Score: " + score;

        //If score is multiple of 100, player will gain some health 
        if (score !=0 && score % 100 == 0)
        {
            PlayerHealthManager.currentHealth += gainedHealth;
        }
    } */


}
