using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;



public class AdManager : MonoBehaviour
{


    public MenuScene s;  //For Gold Updation
    public GameObject RewardPanel;
    



    public static AdManager instance;

    private string appID = "ca-app-pub-2469916278411398~8495848528";

    private RewardBasedVideoAd rewardedAd;
    private string rewardedAdID = "ca-app-pub-2469916278411398/9159221173";
    private void Awake()
    {
     
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }



    private void Start()
    {
       // DontDestroyOnLoad(gameObject);
        rewardedAd = RewardBasedVideoAd.Instance;

        RequestRewardedAd();

        rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
    }






    public void OnDestroy()
    {
        rewardedAd.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;

        rewardedAd.OnAdRewarded -= HandleRewardBasedVideoRewarded;
    }




    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request, rewardedAdID);
    }

    public void showRewardedAd()
    {
        if(rewardedAd.IsLoaded())
        {
            Debug.Log("hryryry");
            //RewardPanel.SetActive(true);
            rewardedAd.Show();
           

        }
        else
        {
            Debug.Log("Reawrded ad not Loaded");
            
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Debug.Log("AD loaded Successfully");
    }


    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("FAiled To Load AD ");
        // sorry try again
        RequestRewardedAd();


    }


    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;

   
        RewardPanel.SetActive(true);

        Debug.Log("You Have Been Reawrded" + amount.ToString() + " " + type);

       

    }


    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        Debug.Log("Video HAs Closed ");
        
        RequestRewardedAd();

    }



}

