using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class check_point_audio : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject target;
    public GameObject Blue;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //target�ɓ���������܂������ĊJ����
        float distanceOfPlayer = Vector3.Distance(target.transform.position, Blue.transform.position);
        //Debug.Log(distanceOfPlayer+" �̋���������");

        if (distanceOfPlayer < 2.0f)
        {
            audioSource.UnPause();
        }

    }

    void OnTriggerEnter(Collider other)
    { 
        //2�ڂ̒��Ԓn�_�ŉ�����U�~�߂�
        Vector3 pos2 = new Vector3(4.4f, -5.0f, 0.0f);
        if (transform.position == pos2)
        {
            audioSource.Pause();
        }


        //3�ڂ̒��Ԓn�_�ŉ����~�߂�
        Vector3 pos3 = new Vector3(13.0f, -6.0f, 0.0f);
        if (transform.position == pos3)
        {
            audioSource.Stop();
        }
    }

}
