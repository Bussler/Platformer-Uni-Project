using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuswählbaresLevel : MonoBehaviour {
    public int LevelIndex;
    private MeshRenderer renderer;
    private bool canBeClicked;
    public string LevelName;

	// Use this for initialization
	void Start () {
        this.renderer = this.GetComponent<MeshRenderer>();
		if(LevelManager.getFreigeschaltet() < LevelIndex)
        {
            this.renderer.material.color =  new Color32(40, 40, 40,255);
            canBeClicked = false;
        }
        else
        {
            canBeClicked = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (canBeClicked)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                
                SceneManager.LoadScene(LevelName);
            }
        }
    }
}
