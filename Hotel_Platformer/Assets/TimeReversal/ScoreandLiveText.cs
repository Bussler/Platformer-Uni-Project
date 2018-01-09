using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreandLiveText : MonoBehaviour {

    public Text text;

	
	void Start () {
        text = this.gameObject.GetComponent<Text>();
        text.text = "Score: " + GameData.Instance.Score+"\nLives: "+GameData.Instance.Lives;
	}
	
	public void UpdateScore()
    {
        text.text = "Score: " + GameData.Instance.Score + "\nLives: " + GameData.Instance.Lives;
    }
}
