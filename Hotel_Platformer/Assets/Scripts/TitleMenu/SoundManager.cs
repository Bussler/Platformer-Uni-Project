using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

     static  float MasterVolume = 1;
    static bool mute = false;
    static float MasterVolumeSaved;
	string mastervolumeKEY= "MASTERVOLUME";
    public AudioSource audioo;

    void Start()
    {
        MasterVolume = getVolume();
        audioo.volume = MasterVolume;
        
    }

    void Update()
    {
        audioo.volume = MasterVolume;
    }


    static public float getVolume()
    {
        return PlayerPrefs.GetFloat("MASTERVOLUME");
    }

    static public void setVolume(float v)
    {
        MasterVolume = v;
        PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);
    }

    static public void MasterVolumeUp(float add)
    {
        if (MasterVolume + add <= 1)
        {
            MasterVolume = MasterVolume + add;
            PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);
        }else
        if(MasterVolume + add > 1)
        {
            MasterVolume = 1;
            PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);
        }
    }

    static public void MasterVolumeDown(float sub)
    {
        if (MasterVolume - sub>=0)
        {
            MasterVolume = MasterVolume - sub;
            PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);
        }else
        if (MasterVolume - sub < 0)
        {
            MasterVolume = 0;
            PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);
        }

    }
    static public void Mute()
    {
        if (!mute)
        {
            MasterVolumeSaved = MasterVolume;
            MasterVolume = 0;
            mute = true;
            PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);

        }
        else
        {
            mute = false;
            MasterVolume = MasterVolumeSaved;
            PlayerPrefs.SetFloat("MASTERVOLUME", MasterVolume);

        }


    }

}
