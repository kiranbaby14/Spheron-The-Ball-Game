using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScene : MonoBehaviour
{
  
    public RectTransform menuContainer;


    public Transform colorPanel;
    


    public Text colorBuySetText;
    
    public Text goldText;

    private MenuCamera menuCam;


    private int[] colorCost = new int[] { 0, 100, 150, 200, 250,300 , 60, 80, 90, 1000 };

    private int selectedColorIndex;
    
    private int activeColorIndex;
    

    private Vector3 desiredMenuPosition;



    // Start is called before the first frame update
    void Start()
    {
        //fadeGroup = FindObjectOfType<CanvasGroup>();
        //fadeGroup.alpha = 1;
        menuCam = FindObjectOfType<MenuCamera>();


        //SaveManager.Instance.state.gold = 0;

        //SetCameraTo(Manager.Instance.menuFocus);
        UpdateGoldText();
        InitShop();

        OnColorSelect(SaveManager.Instance.state.activeColor);
        SetColor(SaveManager.Instance.state.activeColor);

        
        


        colorPanel.GetChild(SaveManager.Instance.state.activeColor).GetComponent<RectTransform>().localScale = Vector3.one * 1.125f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
        //fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
    }
    


    private void InitShop()
    {
        if (colorPanel == null )
            Debug.Log("you did not asssign the panel");

        int i = 0;
        foreach(Transform t in colorPanel)
        {
            int currentIndex = i;
            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnColorSelect(currentIndex));


            Image img = t.GetComponent<Image>();
            img.color = SaveManager.Instance.IsColorOwned(i) ?
                Manager.Instance.playerColors[currentIndex]
                : Color.Lerp(Manager.Instance.playerColors[currentIndex], new Color(0,0,0,1),0.25f);
            i++;
        }
        


    }


    //private void SetCameraTo(int menuIndex)
    //{
     //   NavigateTo(menuIndex);
      //  menuContainer.anchoredPosition3D = desiredMenuPosition;
    //}


    private void NavigateTo(int menuIndex)
    {
        switch(menuIndex)
        {
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                menuCam.BackToMainMenu();
                break;

            case 1:
                desiredMenuPosition = Vector3.left * 972;
                menuCam.MoveToShop();
                break;
        }
    }




    private void SetColor(int index)
    {
        activeColorIndex = index;
        SaveManager.Instance.state.activeColor = index;

        Manager.Instance.playerMaterial.color = Manager.Instance.playerColors[index];
        colorBuySetText.text = "Applied";

        SaveManager.Instance.Save();
    }



    public void UpdateGoldText()
    {
        goldText.text = SaveManager.Instance.state.gold.ToString();
    }
    public void OnPlayClick()
    {
        Debug.Log("ho");
    }
    public void OnShopClick()
    {

        NavigateTo(1);
        Debug.Log("hoyaa");

    }

    public void OnBackClick()
    {

        NavigateTo(0);
        Debug.Log("Back button");
    }

   
    private void OnColorSelect(int currentIndex)
    {
        Debug.Log("color");

        if (selectedColorIndex == currentIndex)
            return;
        colorPanel.GetChild(currentIndex).GetComponent<RectTransform>().localScale = Vector3.one * 1.250f;
        colorPanel.GetChild(selectedColorIndex).GetComponent<RectTransform>().localScale = Vector3.one;
        selectedColorIndex = currentIndex;

        if(SaveManager.Instance.IsColorOwned(currentIndex))
        {
            if(activeColorIndex == currentIndex)
            {
                colorBuySetText.text = "Current Color";
            }
            else
            {
                colorBuySetText.text = "Select Color";
            }
            

        }
        else
        {
            colorBuySetText.text = "Buy: " + colorCost[currentIndex].ToString();
        }
    }

    public void OnColorBuySet()
    {
        Debug.Log("color buy");
        if(SaveManager.Instance.IsColorOwned(selectedColorIndex))
        {
            SetColor(selectedColorIndex);
        }
        else
        {
            if(SaveManager.Instance.BuyColor(selectedColorIndex, colorCost[selectedColorIndex]))
            {
                SetColor(selectedColorIndex);

                colorPanel.GetChild(selectedColorIndex).GetComponent<Image>().color = Manager.Instance.playerColors[selectedColorIndex]; 

                UpdateGoldText();
                    
            }
            else
            {

            }
        }
    }

   
}
