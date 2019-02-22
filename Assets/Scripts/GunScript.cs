using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    AudioSource audio;
    public static GunScript instance;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void fireSound()
    {
        audio.Play();
    }

}
