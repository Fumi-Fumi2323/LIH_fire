using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class goal_audio : MonoBehaviour
{ 
    AudioSource audioSource;
    GameObject Blue;
    public GameObject pre_check_point;
    public bool music_on;
    

    void Start()
    {
        Blue = GameObject.FindGameObjectWithTag("Blue");

        audioSource = this.GetComponent<AudioSource>();
        audioSource.Stop();
        music_on = true;
    }

    void Update()
    {
        if (music_on)
        {
            if (pre_check_point == null)
            {
                audioSource = this.GetComponent<AudioSource>();
                audioSource.Play();
                music_on = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        //ÉSÅ[ÉãÇ‹Ç≈ìûíBÇµÇΩÇÁ2ïbå„Ç…âπÇé~ÇﬂÇÈ
        if (other.CompareTag("range"))
        {
            Invoke("music_stop", 2.0f);

        }

    }
    void music_stop()
    {
        audioSource.Stop();
    }

}
