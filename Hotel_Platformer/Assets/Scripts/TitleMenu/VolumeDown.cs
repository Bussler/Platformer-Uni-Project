using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDown : MonoBehaviour {
    public float down;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SoundManager.MasterVolumeDown(down);

        }
    }
}
