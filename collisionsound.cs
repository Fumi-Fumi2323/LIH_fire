using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionsound : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip audioclip;

    void Start()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("range"))
        {
            audiosource.PlayOneShot(audioclip);   
        } 
    }
}
