using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_point_2 : MonoBehaviour
{ 

    AudioSource audioSource;
    public  bool first_checkpoint;
    public GameObject next_check_point;
    public bool last_check_point;
    private bool next_visible = false;
 

    void Start()
    {
        
        //���߂Ẵ`�F�b�N�|�C���g�łȂ��Ȃ��\��
        if (!first_checkpoint)
        {
            gameObject.SetActive(false);
        }

        if(first_checkpoint)
        {
            audioSource = this.GetComponent<AudioSource>();
            audioSource.Play();
        }

        next_visible = false;

    }


    public void Update()
    {
        //2.���̃`�F�b�N�|�C���g��\��
        if (next_visible)
        {
            next_check_point.SetActive(true);
            next_visible = false;
            Destroy_on();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // 1.range�^�O�ɐڐG
        if (other.CompareTag("range")) 
        {
            if (!last_check_point)
            {
                next_visible = true;
            }
            else 
            {
                Destroy_on();
            }
            audioSource = this.GetComponent<AudioSource>();
            audioSource.Stop();
        }
    }

    void Destroy_on()
    {
        Destroy(gameObject);
    }
}
