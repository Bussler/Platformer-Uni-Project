using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialtilling : MonoBehaviour {
    private MeshRenderer rendererr;
    public float offset;
   public float n = 1;
    public float time;
	// Use this for initialization
	void Start () {
        rendererr = this.GetComponent<MeshRenderer>();
        n = Random.Range(-offset, offset);
        Invoke("SetN", time);
	}
	
	// Update is called once per frame
	void Update () {
        rendererr.material.mainTextureOffset += new Vector2(n*Time.deltaTime,n*Time.deltaTime);
       
       
	}
    public void SetN()
    {
        
        n= Random.RandomRange(-offset, offset);
        Invoke("SetN", time);
    }
}
