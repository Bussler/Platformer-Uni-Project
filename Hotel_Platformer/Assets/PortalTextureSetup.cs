using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

    public Camera cameraB;
    public Material material;


	// Use this for initialization
	void Start () {
		if(cameraB.targetTexture != null) {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        material.mainTexture = cameraB.targetTexture;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
