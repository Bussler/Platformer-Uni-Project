using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Transform canvas;

	// Update is called once per frame
	void Update () {

        //deactivate/activate the menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy==false)
            {
                canvas.gameObject.SetActive(true);//activate
                Time.timeScale = 0;//pauses the game
            }
            else
            {
                canvas.gameObject.SetActive(false);//deactivate
                Time.timeScale = 1;//normal timeflow
            }
    }

    //ButtonControl

}
