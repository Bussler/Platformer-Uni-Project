using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeUp : MonoBehaviour {
    public float add;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseOver()
    {
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("VolumeUp");
            SoundManager.MasterVolumeUp(add);

        }
    }
}
