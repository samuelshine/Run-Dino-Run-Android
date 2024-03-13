using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectibleControl : MonoBehaviour
{
    public static float coinCount;
    public GameObject coinCountDisplay;
    void Start()
    {
        if(PlayerPrefs.GetFloat("CoinCount")!=null)
        {
            coinCount=PlayerPrefs.GetFloat("CoinCount");
        }
    }
    void Update()
    {
        coinCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text=coinCount.ToString();
    }
}
