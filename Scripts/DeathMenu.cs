using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static DeathMenu instance;
    public Text scoreText;
    public Transform df;
    public Transform ee;
    public PlayerMotor je;
    public Score jf;
    public SaveManager sm;
    public Text extraLifeBuyText;
    public MenuScene s;
    public GameObject RewardPanel;
  

    
    

    void Start()
    {
        s.UpdateGoldText();
        gameObject.SetActive(true);
        //RewardPanel.SetActive(true);

    }



    

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
    }
    public void Restart()
    {

        
        SceneManager.LoadScene("level01");



    }

    public void ToMenu()
    {

        SceneManager.LoadScene("Menu");
    }

    public void ExtraLife()
    {
        if(GameManager.Instance.lastCheckPoint.position == ee.position)
        {
            s.UpdateGoldText();
            extraLifeBuyText.text = "No CheckPoints Covered";
        }
        else
        {
            df.position = GameManager.Instance.lastCheckPoint.position;
            if (GameManager.Instance.lastCheckPoint.position == df.position)
            {

                if ((sm.state.gold - 200) >= 0)
                {
                   
                    Debug.Log("MOneyMoney");
                    SaveManager.Instance.state.gold -= 200;
                    s.UpdateGoldText();
                    SaveManager.Instance.Save();

                    gameObject.SetActive(false);
                    je.isDead = false;
                    jf.isDead = false;
                }
                else
                {
                    s.UpdateGoldText();
                    extraLifeBuyText.text = "Not Enough Coins";
                }


            }
        }
 

        

    }


    public void ReceiveReward()
    {
        SaveManager.Instance.state.gold += 100;
        s.UpdateGoldText();
        SaveManager.Instance.Save();
        if ((sm.state.gold - 200) >= 0)
            extraLifeBuyText.text = "Continue From Last Checkpoint 200 Coins";
        RewardPanel.SetActive(false);
    }

}
