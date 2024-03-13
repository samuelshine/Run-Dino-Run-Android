using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBlink : MonoBehaviour
{
    public float blinkTime=2f;
    public GameObject textFlicker;
    void Update()
    {
        while(true)
        {
            StartCoroutine(blinkRoutine());
        }
    }
    IEnumerator blinkRoutine()
	{
		textFlicker.GetComponent<TMPro.TextMeshProUGUI>().enabled=false;
		yield return new WaitForSeconds(2);
		textFlicker.GetComponent<TMPro.TextMeshProUGUI>().enabled=true;
	}
}
