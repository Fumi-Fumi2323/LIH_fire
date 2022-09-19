using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signal : MonoBehaviour
{
    public GameObject val_wall;
    public float seconds;
    public AudioSource m_AudioSource;
    public string signal_state;

    // Start is called before the first frame update
    private void Start()
    {
        //DelayMethodを0.0秒後に呼び出し、以降は10秒毎に実行
        InvokeRepeating(nameof(DelayMethod), 0.0f, 10.0f);
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
        //m_AudioSource.loop = false;
        m_AudioSource.mute = true;
    }

    void DelayMethod()
    {
        //Debug.Log("Delay call");
        GetComponent<Renderer>().material.color = Color.cyan;
        seconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 2 && seconds <= 8)
        {
            GetComponent<Renderer>().material.color = Color.red;
            if (seconds >= 4 && seconds <= 6)
            {
                GetComponent<Renderer>().material.color = Color.red;
                val_wall.GetComponent<Renderer>().material.color = Color.red;
                m_AudioSource.loop = true;
                signal_state = "red";
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.yellow;
                val_wall.GetComponent<Renderer>().material.color = Color.blue;
                signal_state = "yellow";
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.cyan;
            val_wall.GetComponent<Renderer>().material.color = Color.blue;
            signal_state = "blue";
        }
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("当たっている");
        if (signal_state != "blue")
        {
            m_AudioSource.mute = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("離れた!");
        m_AudioSource.mute = true;
    }
}
