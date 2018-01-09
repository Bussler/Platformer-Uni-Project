using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuTransition : MonoBehaviour {

    private Camera camera;
    private Animator anim;
    // Use this for initialization
    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        anim = camera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}

   public void StartTransition()
    {
        Debug.Log("Start");
        anim.SetTrigger("Start");
    }
    public void StartBackTransition()
    {

    }
    public void OptionsTransition()
    {

    }
    public void OptionsBackTransition()
    {

    }
    public void Quit()
    {

    }



}
