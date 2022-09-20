using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class goal_audio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    GameObject Blue;
    float distanceOfPlayer;
    //Destination destination;
    public GameObject pre_check_point;
    public GameObject pre_target;
    public bool music_on;

 
    void Start()
    {
        Blue = GameObject.FindGameObjectWithTag("Blue");

        audioSource = this.GetComponent<AudioSource>();
        audioSource.Stop();

        //target = GameObject.FindGameObjectWithTag("target");
        //destination = target.GetComponent<Destination>();

        music_on = true;
    }

    void Update()
    {
        
        Debug.Log("�ł�");
        if (music_on)
        {
            if (pre_check_point == null)
            {
                Debug.Log("�ł��Ă�");
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
