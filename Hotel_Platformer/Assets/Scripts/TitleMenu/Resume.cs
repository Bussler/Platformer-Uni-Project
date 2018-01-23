using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour {


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

            switch (LevelManager.getFreigeschaltet())
            {
                case 0:
                    SceneManager.LoadScene("Lobby"); break;

                    break;
                case 1: SceneManager.LoadScene("Level1");break;
                case 2: SceneManager.LoadScene("Level2"); break;
                case 3: SceneManager.LoadScene("Level3"); break;
                case 4: SceneManager.LoadScene("Level4"); break;
                

            }

        }
    }

}
