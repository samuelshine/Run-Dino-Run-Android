using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    public float waitTime;
    public Animator musicAnim;
    public Animator transitionAnim;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).tapCount == 2)
        {
            StartCoroutine(changeScene());
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator changeScene()
    {
        transitionAnim.SetTrigger("End");
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}
