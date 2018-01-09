using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class BlinkingPlatform : MonoBehaviour {
    public float TimeBetweenDissapear;
    public float DissaperTime;
    private Collider colliderr;
    private MeshRenderer rendererr;
    private bool isVisible;
   private float time = 0;
    // Use this for initialization
    void Start () {
        colliderr = this.GetComponent<Collider>();
        rendererr = this.GetComponent<MeshRenderer>();
        isVisible = true;
       
    }

    // Update is called once per frame
    void Update() {
       
       

        if (isVisible)
        {
            time = time + Time.deltaTime;
            if (time > TimeBetweenDissapear)
            {
                time = 0;
                rendererr.enabled = false;
                colliderr.enabled = false;
                isVisible = false;
            }
        }
        if (!isVisible)
        {
            time = time + Time.deltaTime;
            if (time > DissaperTime)
            {
                time = 0;
                rendererr.enabled = true;
                colliderr.enabled = true;
                isVisible = true;
            }
        }
    }
	



}
