using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;
    
    

    void FixedUpdate()
    {

        scoreText.GetComponent<Text>().text = "Coins: " + theScore;
       
    }
}
