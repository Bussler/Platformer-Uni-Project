using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {
    private bool hasInput = false;
    public int disappearingSpeed;
    public Text text;
    public static bool isDestroyed = false;
    public float x = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            hasInput = true;
        }

        if (hasInput)
        {
          //  Debug.Log("Input");
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, GetComponent<Image>().color.a - disappearingSpeed * Time.deltaTime);
            if (x == 0)
            {
                Destroy(text.gameObject);
            }
            x=x+disappearingSpeed*Time.deltaTime;
        }
        if (x>=1)
        {
            Debug.Log("destoying");
            isDestroyed = true;
            Destroy(this.gameObject);


        }


	}
}
