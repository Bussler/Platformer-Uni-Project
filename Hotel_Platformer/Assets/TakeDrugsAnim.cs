using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class TakeDrugsAnim : MonoBehaviour {

    public FirstPersonController firstPersonController;
    public GameObject plane;
    public Animator animator;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDrugsanim()
    {
        firstPersonController.enabled = true;
        Destroy(plane);
        this.transform.localPosition = new Vector3(0, 1, 0);
        this.transform.localRotation = new Quaternion(0, 0, 0,0);
        animator.enabled = false;
        part1.active = true;
        part2.active = true;
        part3.active = true;
        this.transform.parent.position = new Vector3(4.17f, 0.4f, -1.37f);
    }
}
