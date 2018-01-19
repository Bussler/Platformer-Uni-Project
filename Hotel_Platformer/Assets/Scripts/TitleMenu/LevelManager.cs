using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    static int freigeschaltet = 0;
    public int ThisLevelIndex;
    private string freigeschaltetKEY= "FREIGESCHALTET";


	// Use this for initialization
	void Start () {


        freigeschaltet = PlayerPrefs.GetInt("FREIGESCHALTET");

        if (freigeschaltet < ThisLevelIndex)
        {
            freigeschaltet = ThisLevelIndex;
            PlayerPrefs.SetInt("FREIGESCHALTET", freigeschaltet);
        }
        
	}

   static public int getFreigeschaltet()
    {

        return PlayerPrefs.GetInt("FREIGESCHALTET");
    }
    
   static public void setFreigeschaltet(int i)
    {
        PlayerPrefs.SetInt("FREIGESCHALTET", i);
    }

	
	
}
