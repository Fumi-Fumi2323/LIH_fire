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
        //targetに当たったらまた音を再開する
        float distanceOfPlayer = Vector3.Distance(target.transform.position, Blue.transform.position);
        //Debug.Log(distanceOfPlayer+" の距離がある");

        if (distanceOfPlayer < 2.0f)
        {
            audioSource.UnPause();
        }

    }

    void OnTriggerEnter(Collider other)
    { 
        //2個目の中間地点で音を一旦止める
        Vector3 pos2 = new Vector3(4.4f, -5.0f, 0.0f);
        if (transform.position == pos2)
        {
            audioSource.Pause();
        }


        //3個目の中間地点で音を止める
        Vector3 pos3 = new Vector3(13.0f, -6.0f, 0.0f);
        if (transform.position == pos3)
        {
            audioSource.Stop();
        }
    }

}
