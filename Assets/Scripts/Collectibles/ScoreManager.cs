using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject hiScoreText;
    public static float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore")!=null)
        {
            hiScoreCount=PlayerPrefs.GetFloat("HighScore");
        }
        scoreCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing)
        {
            scoreCount+=pointsPerSecond*Time.deltaTime;
        }
        if(scoreCount>hiScoreCount)
        {
            hiScoreCount=scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text=Mathf.Round(scoreCount).ToString();
        hiScoreText.GetComponent<TMPro.TextMeshProUGUI>().text=Mathf.Round(hiScoreCount).ToString();
    }
}
