using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;
    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        ScoreManager.scoreCount+=2;
        CollectibleControl.coinCount+=1;
        this.gameObject.SetActive(false);
    }
}
