using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (SplashScreen.isDestroyed)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    public void OnMouseOver()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && SplashScreen.isDestroyed == true)
        {
            Application.Quit();
           

        }
    }

}
