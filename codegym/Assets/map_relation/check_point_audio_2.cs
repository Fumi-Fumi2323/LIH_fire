using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_point_audio_2 : MonoBehaviour
{
    AudioSource audioSource;
    bool music_on;
    public GameObject pre_check_point;
    public GameObject pre_target;
    GameObject Blue;

    void Start()
    {
        Blue = GameObject.FindGameObjectWithTag("Blue");
        music_on = true;
    }


    void Update()
    {
        if (pre_target == null) //‘O‚ªtarget‚Å‚È‚¢‚Æ‚«
        {

            if (pre_check_point == null)
            {
                if (music_on)
                {
                    Debug.Log("‚©‚«");
                    audioSource = this.GetComponent<AudioSource>();
                    audioSource.Play();
                    music_on = false;
                }
            }
            
            
        }
        else
        {

            if (pre_target.GetComponent<Renderer>().material.color == Color.white)
            {
                if (music_on)
                {
                    Debug.Log("‚©‚«‚­");
                    audioSource = this.GetComponent<AudioSource>();
                    audioSource.Play();
                    music_on = false;
                }

            }
        }
    }

}