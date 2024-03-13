using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModelSwap : MonoBehaviour
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
    [SerializeField]
    Rigidbody rb;
    bool jump;

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
            if(meshCount>=2)
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
    IEnumerator meshPause()
    {
        mf.mesh=meshes[meshCount];
        yield return new WaitForSeconds(5);
        mf.mesh=meshes[meshCount];
    }
}
