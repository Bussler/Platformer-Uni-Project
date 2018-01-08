using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRotatePlattform : MonoBehaviour {
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;
    public float rotateSpeed;

    //Koordinaten des Punktes
    public float xKoordinate;
    public float yKoordinate;
    public float zKoordinate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotateX==true)
        {
            transform.RotateAround(new Vector3(xKoordinate,yKoordinate,zKoordinate),Vector3.right, 5*rotateSpeed*Time.deltaTime);
        }
        else
        {
            if (rotateY==true)
            {
                transform.RotateAround(new Vector3(xKoordinate, yKoordinate, zKoordinate), Vector3.up, 5 * rotateSpeed * Time.deltaTime);
            }
            else
            {
                if (rotateZ==true)
                {
                    transform.RotateAround(new Vector3(xKoordinate, yKoordinate, zKoordinate), Vector3.forward, 5 * rotateSpeed * Time.deltaTime);
                }
            }
        }
	}
}
