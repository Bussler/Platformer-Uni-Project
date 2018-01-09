﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    private Camera camera;
    private Animator anim;
    // Use this for initialization
    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        anim = camera.GetComponent<Animator>();
    }

    public void OnMouseOver ()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0) && SplashScreen.isDestroyed == true)
        {
           
            anim.SetTrigger("Start");

        }
    }


}