using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeradactyleSwap : MonoBehaviour
{
    [SerializeField]
    MeshFilter mf;

    [SerializeField]
    float timer,timerMax;

    Mesh mesh;
    [SerializeField]
    Mesh[] meshes;

    [SerializeField]
    int meshCount;
    // Start is called before the first frame update
    void Start()
    {
        mesh=mf.mesh;
        meshCount=0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>timerMax)
        {
            mf.mesh=meshes[meshCount];
            meshCount++;
            if(meshCount>=3)
            {
                meshCount=0;
            }
            timer=0;
        }
        else
        {
            timer+=Time.deltaTime;
        }
        
    }
}
