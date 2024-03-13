using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).tapCount == 2)
        {
            StartCoroutine(changeScene());
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator changeScene()
    {
        transitionAnim.SetTrigger("End");
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
    }
}
