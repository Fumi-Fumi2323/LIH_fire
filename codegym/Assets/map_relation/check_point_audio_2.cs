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
    Vector3 pos_ch;
    Vector3 pos_tar;


    void Start()
    {
        Blue = GameObject.FindGameObjectWithTag("Blue");
        music_on = true;

        pos_ch = pre_check_point.transform.position;
        pos_tar = pre_target.transform.position;
        Debug.Log(pos_tar);
    }


    void Update()
    {
        if (pre_target == null) //�O��target�łȂ��Ƃ�
        {

            Debug.Log("������");
            
            if (pre_check_point == null)
            {
                if (music_on)
                {
                    Debug.Log("����");
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
                    Debug.Log("������");
                    audioSource = this.GetComponent<AudioSource>();
                    audioSource.Play();
                    music_on = false;
                }

            }
        }
    }

}