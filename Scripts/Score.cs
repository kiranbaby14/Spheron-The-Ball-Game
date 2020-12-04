using System;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public Text highscoreText;
    public DeathMenu deathMenu;
    public PlayerMotor pm;



    private int difficultyLevel = 11;
    private int maxDifficultyLevel = 21;
    private int scoreToNextLevel = 200;
    private int scoreSpeedIncrement = 4;

    public bool isDead = false;


    private CharacterController controller;
    private float score = 0.0f;
    
    void Start()
    {
        highscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
        controller = GetComponent<CharacterController>();
        
    }
    void FixedUpdate()
    {


        if (isDead)
            return;

        
        //==============important=======================
        // for stopping score to increse with animation
        if (player.position.z == -35f)
        {
           
            return;
        }



        if (score >= scoreToNextLevel)
            LevelUp();


        if (pm.WhiteOb == false)
        {
            score += Time.deltaTime * scoreSpeedIncrement;
            scoreText.text = ((int)score).ToString();
            
        }

        else if(pm.WhiteOb)
        {
            pm.WhiteOb = false;
        }




        if (PlayerPrefs.GetFloat("Highscore") < score)
        {

            
            PlayerPrefs.SetFloat("Highscore", score);
            highscoreText.text = "New Highscore: " + ((int)score).ToString();


        }


    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;


        scoreToNextLevel *= 2;
        difficultyLevel += 2;
        scoreSpeedIncrement += 2;
        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;

               
        deathMenu.ToggleEndMenu(score);
    }
}
