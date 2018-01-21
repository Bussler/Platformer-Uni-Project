using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour1 : MonoBehaviour {
    public float threshold;
    public float distance;
    private float maxSpeed;
    private float acceleration;
    public float step;
    private Vector3 startPos;
    private Vector3 dir;
    private Vector3 endPos;

    void Start()
    {
        maxSpeed = Random.Range(0f, 2f);
        startPos = transform.position;
        dir = Vector3.up;
        acceleration = 0F;
        endPos = new Vector3(startPos.x, startPos.y + distance, startPos.z);
    }
    

    // Update is called once per frame
    void Update () {
        if (acceleration < maxSpeed && transform.position.y<=endPos.y)
        {
            acceleration += step;
        }
        if (transform.position.y >= endPos.y - threshold  )
        {
            acceleration -= step;
        }
        

        transform.Translate(new Vector3(0, dir.y * acceleration *maxSpeed  , 0).normalized*Time.deltaTime);

        if (transform.position.y >= endPos.y)
        {
            acceleration = acceleration -step;
        }

    }
}
