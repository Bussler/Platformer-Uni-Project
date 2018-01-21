using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour2 : MonoBehaviour {

    private float dir;
    private Vector3 start;
    private Vector3 end;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public float distance;

	// Use this for initialization
	void Start () {
        start = new Vector3(transform.position.x-distance/2, transform.position.y, transform.position.z);
        end = new Vector3(transform.position.x + distance / 2, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        
        if(dir == 1)
        {
            transform.position = Vector3.SmoothDamp(transform.position, start, ref velocity, smoothTime);
        } else
        {
            transform.position = Vector3.SmoothDamp(transform.position, end, ref velocity, smoothTime);
        }
        if (transform.position == start)
        {
            velocity = Vector3.zero;
            dir *= -1;
        } else if (transform.position == end)
        {
            velocity = Vector3.zero;
            dir *= -1;
        }

    }
}
