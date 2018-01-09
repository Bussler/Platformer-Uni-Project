using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("TimeControl"))
            GameData.Instance.Paused = true;
        if (Input.GetButtonUp("TimeControl"))
            GameData.Instance.Paused = false;
    }
}
