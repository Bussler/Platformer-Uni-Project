using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour1 : MonoBehaviour {
    private short dir;
    private int counter;
    private float speed;
    private Vector3 pos;
    private float smoothTime = 0.8f;
    private Vector3 velocity= Vector3.up;
    private Vector3 targetPosition;

    void Start()
    {
        dir = 1;
        counter = 0;
         pos = transform.position;
         targetPosition = new Vector3(pos.x, pos.y + 10f, pos.z);
    }
	
	// Update is called once per frame
	void FixedUpdate () {


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        if (transform.position.y >= targetPosition.y && velocity == Vector3.up)
        {
            velocity=Vector3.down;
            targetPosition = new Vector3(targetPosition.x, targetPosition.y - 10f, targetPosition.z);
        } else if(transform.position.y <= targetPosition.y && velocity == Vector3.down)
        {
            velocity = Vector3.up;
            targetPosition = new Vector3(pos.x, pos.y - 10f, pos.z);
        }
        
    }
}
