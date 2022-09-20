using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amove2 : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject start = GameObject.FindGameObjectWithTag("start");
        Vector3 pos = start.transform.position;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;

        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        Vector3 rotateDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) rotateDir.y = -1f;
        if (Input.GetKey(KeyCode.D)) rotateDir.y = 1f;
        transform.Rotate(rotateDir, Time.deltaTime * 100f);
    }
}
