using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Transform targrtFocus;

    void Start()
    {
        targrtFocus = GameObject.FindGameObjectWithTag("target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = targrtFocus.position - this.transform.position;

        if(target.magnitude < 1)
        {
            TargetColider.instance.moveTarget();
        }

        this.transform.LookAt(targrtFocus.position);
        float speed = Random.Range(15f, 30f);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
