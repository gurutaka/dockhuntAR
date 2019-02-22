using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Vuforia;

public class TargetColider : MonoBehaviour
{
    public static TargetColider instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        moveTarget();
    }


    public void moveTarget()
    {
        Vector3 tmp;
        tmp.x = Random.Range(-48f, 48);
        tmp.y = Random.Range(10f, 50f);
        tmp.z = Random.Range(-48f, 48f);
        this.transform.position = new Vector3(tmp.x, tmp.y,tmp.z);
        //if(DefaultTrackableEventHandler.trueFalse == true)
        //{
        //    RaycastController.instance.playSound(0);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
