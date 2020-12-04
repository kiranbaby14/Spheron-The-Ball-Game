using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public AudioSource collectSound;
    public Transform tp;

    private void Start()
    {

        if (tp.position.z == -35f)
        {
            CoinScript.theScore = 0;
            Debug.Log("scoreyreyers");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        SaveManager.Instance.state.gold++;
        SaveManager.Instance.Save();
        Destroy(gameObject);

        collectSound.Play();
        CoinScript.theScore += 1;
       
    }
}
