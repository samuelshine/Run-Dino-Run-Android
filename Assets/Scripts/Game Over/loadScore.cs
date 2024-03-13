using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScore : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject hiScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text="YOUR SCORE: "+Mathf.Round(PlayerPrefs.GetFloat("CurrentScore")).ToString();
        hiScoreText.GetComponent<TMPro.TextMeshProUGUI>().text="HIGH SCORE: "+Mathf.Round(PlayerPrefs.GetFloat("HighScore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
