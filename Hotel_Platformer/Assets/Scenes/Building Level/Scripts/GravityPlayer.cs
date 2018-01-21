using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]

public class GravityPlayer : MonoBehaviour {

    GravityAttractor sphere;

	// Use this for initialization
	void Awake () {
        sphere = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        sphere.Attract(transform);
	}
}
