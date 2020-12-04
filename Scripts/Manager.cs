using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { set; get; }
    public Material playerMaterial;


    public Color[] playerColors = new Color[10];

    
    public GameObject[] playerTrails = new GameObject[10];

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;

    }

    //public int currentLevel = 0;
    public int menuFocus = 0;

}
