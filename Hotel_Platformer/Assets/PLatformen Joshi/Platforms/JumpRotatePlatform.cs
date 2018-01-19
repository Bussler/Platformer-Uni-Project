using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRotatePlatform : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = this.transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
          //  Debug.Log("Rotate");
            anim.SetTrigger("Jump");

        }
	}
}
