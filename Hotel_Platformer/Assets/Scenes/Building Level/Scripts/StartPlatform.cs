using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour {
    private float formerY;
    private GameObject obj;
    public float uprising;
    // Use this for initialization
    void Start()
    {
       
        formerY = transform.position.y;
        this.transform.position = new Vector3(transform.position.x, transform.position.y - 12, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < formerY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (uprising), transform.position.z);
        }
    }
}
