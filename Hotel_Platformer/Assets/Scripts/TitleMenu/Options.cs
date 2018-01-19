using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    private Camera camera;
    private Animator anim;
    // Use this for initialization
    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        anim = camera.GetComponent<Animator>();
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

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

            anim.SetTrigger("Options");

        }
    }

}
