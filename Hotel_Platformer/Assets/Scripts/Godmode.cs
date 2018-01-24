using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;

public class Godmode : MonoBehaviour {
    public bool godmode;
    public  int speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.G)&& Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.D))
        {
            this.GetComponent<CameraFollow>().enabled = false;
            GameObject.FindObjectOfType<PlayerMovmentTest>().GetComponent<PlayerMovmentTest>().enabled = false;
            godmode = true;
            this.GetComponent<SimpleMouseRotator>().enabled = true;
        }

        if (godmode)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                 transform.Translate(Vector3.left * speed * Time.deltaTime);
               // transform.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.y);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            /*
            if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0)//es ist ein input gegeben
            {
                this.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 50 * Time.deltaTime, Vector3.up);
            }
            if (Mathf.Abs(Input.GetAxis("Mouse Y")) > 0)//es ist ein input gegeben
            {
              //  this.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * 50 * Time.deltaTime, Vector3.right);
            }
            */
            //this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, 0,1);
          

        }
		
	}

    


}
