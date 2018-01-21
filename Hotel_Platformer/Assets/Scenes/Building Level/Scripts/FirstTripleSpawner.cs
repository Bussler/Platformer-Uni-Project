using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTripleSpawner : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    private bool rising = false;

    void Update()
    {
        if(rising == true)
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, transform.position.y - 20, transform.position.z), ref velocity, smoothTime);
    }

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rising = true;
        }
    }
}
