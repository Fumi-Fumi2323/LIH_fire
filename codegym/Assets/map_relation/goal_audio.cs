using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class goal_audio : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject pre_check_point;
    public bool music_on;

    void Start()
    {
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

        //�S�[���܂œ��B������2�b��ɉ����~�߂�
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
