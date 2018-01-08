using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotateBehaviour : MonoBehaviour {
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;
    public float rotateSpeed;
	
	// Update is called once per frame
	void Update () {

        if (rotateX==true)
        {
            transform.Rotate(Vector3.right*rotateSpeed*Time.deltaTime); //Rotate around x axis
        }
        else
        {
            if (rotateY==true)
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime); //Rotate around y axis
            }
            else
            {
                if (rotateZ==true)
                {
                    transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime); //Rotate around z axis
                }
            }
        }
	}

}
