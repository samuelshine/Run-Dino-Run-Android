using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed=8;
    public float leftRightSpeed=8;
	public float jumpSpeed=10;
	public GameObject charModel;
	public static float jumpDelay=0.5f;
	public float jumpHeight=1;
	public float duckHeight=1;
	public float addPerSecond=0.0000001f;
	public float horDistance=1.5f;
	public GameObject thePlayer;
	public AudioSource jumpFX;
	public static float startPause=3f;
    void Update()
    {
		moveSpeed+=addPerSecond*Time.deltaTime;
        transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed, Space.World);
		//transform.position=new Vector3(transform.position.x, 1.25f, transform.position.z);
		Vector3 temp=new Vector3(horDistance, 0, 0);
        if(SwipeManager.swipeLeft)
        {
			if(this.gameObject.transform.position.x>LevelBoundary.leftSide)
			{
				transform.position=new Vector3(this.gameObject.transform.position.x-horDistance, transform.position.y, transform.position.z);
				//StartCoroutine(jumpLeftWait());
				//transform.position = new Vector3(this.gameObject.transform.position.x-horDistance, transform.position.y, transform.position.z);
				//transform.Translate(Vector3.left*Time.deltaTime*leftRightSpeed);
			}
		}
		if(SwipeManager.swipeUp)
        {
			if(this.gameObject.transform.position.y<LevelBoundary.upSide)
			{
				StartCoroutine(jumpWait());
			}
		}
		/*if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
			transform.position=new Vector3(transform.position.x, this.gameObject.transform.position.y-duckHeight, transform.position.z);
			//StartCoroutine(duckWait());
		}*/
		if(SwipeManager.swipeRight)
        {
			if(this.gameObject.transform.position.x<LevelBoundary.rightSide)
			{
				transform.position=new Vector3(this.gameObject.transform.position.x+horDistance, transform.position.y, transform.position.z);
				//StartCoroutine(jumpRightWait());
				//transform.position = new Vector3(this.gameObject.transform.position.x+horDistance, transform.position.y, transform.position.z);
				//transform.Translate(Vector3.left*Time.deltaTime*leftRightSpeed*-1);
			}
		}
    }
	IEnumerator jumpWait()
	{
		jumpFX.Play();
		transform.position=new Vector3(transform.position.x, this.gameObject.transform.position.y+jumpHeight, transform.position.z);
		charModel.GetComponent<ModelSwap>().enabled=false;
		//charModel.GetComponent<Animator>().Play("Jump");
		//transform.Translate(Vector3.up*jumpHeight);
		//transform.Translate(transform.up*Time.deltaTime*leftRightSpeed);
		yield return new WaitForSeconds(jumpDelay);
		transform.position=new Vector3(transform.position.x, this.gameObject.transform.position.y-jumpHeight, transform.position.z);
		charModel.GetComponent<ModelSwap>().enabled=true;
		//transform.Translate(-Vector3.up*jumpHeight);
		//transform.Translate(-transform.up*Time.deltaTime*leftRightSpeed);
		//charModel.GetComponent<Animator>().Play("Standard Run");
	}
	IEnumerator duckWait()
	{
		transform.position=new Vector3(transform.position.x, this.gameObject.transform.position.y-0.5f, transform.position.z);
		yield return new WaitForSeconds(0);
		transform.position=new Vector3(transform.position.x, this.gameObject.transform.position.y+0.5f, transform.position.z);
	}
	IEnumerator jumpLeftWait()
	{
		//charModel.GetComponent<Animator>().Play("Jump");
		//transform.position=new Vector3(this.gameObject.transform.position.x-horDistance, transform.position.y, transform.position.z);
		yield return new WaitForSeconds(jumpDelay);
		//charModel.GetComponent<Animator>().Play("Standard Run");
	}
	IEnumerator jumpRightWait()
	{
		//charModel.GetComponent<Animator>().Play("Jump");
		//transform.position=new Vector3(this.gameObject.transform.position.x+horDistance, transform.position.y, transform.position.z);
		yield return new WaitForSeconds(jumpDelay);
		//charModel.GetComponent<Animator>().Play("Standard Run");
	}
}
