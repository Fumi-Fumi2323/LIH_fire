using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class goal_audio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public GameObject Blue;
    float distanceOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos5 = new Vector3(4.4f, -5.0f, 0.0f);
        distanceOfPlayer = Vector3.Distance(Blue.transform.position, pos5);
    }

    void OnTriggerEnter(Collider other)
    {
        //3�ڂ̒��Ԓn�_�ŉ����o��
        if (distanceOfPlayer < 4.0f)
        {
            audioSource.Play();
        }


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
