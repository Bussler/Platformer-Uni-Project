using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Transform canvas;
    public Transform optionsMenu;
    public AudioSource bMusic;
    public GameObject VolumeSlider;

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
            Cursor.visible = true;//activate cursor
            }
            else
            {
            optionsMenu.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);//deactivate
            Time.timeScale = 1;//normal timeflow
            Cursor.visible = false;//activate cursor
        }
    }

    //ButtonControl

    public void Exit()//Method for loading the start menu
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");
    }

    public void OptionMenuOpen()
    {
        if (optionsMenu.gameObject.activeInHierarchy==false)
        {
            optionsMenu.gameObject.SetActive(true);
        }
        else
        {
            optionsMenu.gameObject.SetActive(false);
        }
    }

    public void MuteMusic()
    {
        bMusic.mute = !bMusic.mute;//mute/play music
    }

    public void VolumeMusic()//calls when the value of the slider is changed
    {
        float newValue = VolumeSlider.GetComponent<Slider>().value;
        bMusic.volume = newValue;
    }
}
