using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaelerPatfrom : MonoBehaviour {
    public  byte Leben;
    private byte maxLeben;
    public MeshRenderer renderer;
    public bool canBeHit= true;
    public Color32[] colors;
    

	// Use this for initialization
	void Start () {
        maxLeben = Leben;
        renderer = this.GetComponent<MeshRenderer>();
        renderer.material.color = colors[maxLeben - Leben];
    }
	
	// Update is called once per frame
	void Update () {
     
        
       
        if (Input.GetButtonDown("Jump"))
        {
            canBeHit = true;
        }

        if (Leben <= 0)
        {
            Destroy(this.gameObject);
        }
	}
    public void ChangeColor()
    {
        if (Leben > 0)
        {
            renderer.material.color = colors[maxLeben - Leben];
        }
    }

}
