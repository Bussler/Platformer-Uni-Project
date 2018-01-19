using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {
    private bool hasInput = false;
    private int disappearingSpeed= 1;
    public Text text;
    public static  bool isDestroyed = false;
    public float x = 0;
    private bool textdes=false;
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            hasInput = true;
        }

        if (hasInput)
        {
            //Debug.Log(""+ disappearingSpeed*Time.deltaTime);
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a - disappearingSpeed * Time.deltaTime);
            if (x == 0)
            {
                if (textdes)
                {
                   
                }
                else
                {
                    textdes = true;
                    Destroy(text.gameObject);
                }
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
