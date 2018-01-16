using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnMouseOver()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && SplashScreen.isDestroyed == true)
        {

            LevelManager.setFreigeschaltet(0);
            SceneManager.LoadScene("Level1");

        }
    }

}
