using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public Transform playerCamera;
    public Transform portalPosition;
    public Transform otherPortalPosition;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 PlayerOffsetFromPortal = playerCamera.position - otherPortalPosition.position;
        transform.position = new Vector3(portalPosition.position.x + PlayerOffsetFromPortal.x, portalPosition.position.y, portalPosition.position.z + PlayerOffsetFromPortal.z);
    }
}
