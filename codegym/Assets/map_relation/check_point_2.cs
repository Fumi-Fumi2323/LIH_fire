using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_point_2 : MonoBehaviour
{ 

    AudioSource audioSource;
    public  bool first_checkpoint;
    public GameObject next_check_point;
    public bool last_target;
    private bool next_visible = false;
    private bool next_music = false;
 

    void Start()
    {
        

        //初めてのチェックポイントでないなら非表示
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
        next_music = false;

    }


    public void Update()
    {
        //2.次のチェックポイントを表示
        if (next_visible)
        {
            next_check_point.SetActive(true);
            next_visible = false;
            Destroy_on();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // 1.rangeタグに接触
        if (other.CompareTag("range")) 
        {
            if (!last_target)
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
