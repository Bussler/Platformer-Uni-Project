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
                  

                    break;
                case 1: SceneManager.LoadScene(1);break;
                case 2: SceneManager.LoadScene(2); break;
                case 3: SceneManager.LoadScene(3); break;
                case 4: SceneManager.LoadScene(4); break;
                case 5: SceneManager.LoadScene(5); break;
                case 6: SceneManager.LoadScene(6); break;
                case 7: SceneManager.LoadScene(7); break;
                case 8: SceneManager.LoadScene(8); break;


            }

        }
    }

}
