using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float moveSpeed=8;
    public float addPerSecond=0.0000001f;
    void Update()
    {
        moveSpeed+=addPerSecond*Time.deltaTime;
        transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed, Space.World);
	}
}
