using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    //Soll wenn die FirstPersonCamer aktiv ist, diese aktivieren, und die ThirdPersonCamera aktivieren + vice versa


    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public bool firstPersonCameraAktiv = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(firstPersonCameraAktiv == false) {
            firstPersonCamera.enabled = false;
            thirdPersonCamera.enabled = true;
        } else {
            firstPersonCamera.enabled = true;
            thirdPersonCamera.enabled = false;
        }
	}
}
