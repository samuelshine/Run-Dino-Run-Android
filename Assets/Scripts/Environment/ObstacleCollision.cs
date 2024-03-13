using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject theCam;
    public GameObject scoreManager;
    public ScoreManager theScoreManager;
    public float endGameDelay=3;
    public AudioSource deathFX;
    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;
    void Start()
    {
        theScoreManager=FindObjectOfType<ScoreManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        deathFX.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled=false;
        thePlayer.GetComponent<PlayerMove>().enabled=false;
        charModel.GetComponent<ModelSwap>().enabled=false;
        theCam.GetComponent<CamMove>().enabled=false;
        scoreManager.GetComponent<ScoreManager>().enabled=false;
        PlayerPrefs.SetFloat("CurrentScore", ScoreManager.scoreCount);
        PlayerPrefs.SetFloat("CoinCount", CollectibleControl.coinCount);
        //charModel.GetComponent<Animator>().Play("Falling Backwards");
        StartCoroutine(changeScene());
    }
    IEnumerator endWait()
    {
        theScoreManager.scoreIncreasing=false;
        yield return new WaitForSeconds(endGameDelay);
        SceneManager.LoadScene(2);
    }
    IEnumerator changeScene()
    {
        transitionAnim.SetTrigger("End");
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(endGameDelay);
        SceneManager.LoadScene(2);
    }
}