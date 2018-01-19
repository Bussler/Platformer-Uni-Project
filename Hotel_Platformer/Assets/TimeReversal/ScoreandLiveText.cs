using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreandLiveText : MonoBehaviour {

    public Text text;
    private PlayerMovmentTest player;

	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovmentTest>();
      
        text.text = "Lives:" + player.health; 
	}
	
	 void Update()
    {
        text.text = "Lives:" + player.health;
    }
}
