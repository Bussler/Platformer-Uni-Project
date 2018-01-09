using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    public float timeBeforFall;
    private float time=0;
    public bool isFalling;
    public float fallingSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFalling)
        {
            time = time + Time.deltaTime;
            if (time > timeBeforFall)
            {
                this.transform.Translate(Vector3.down * fallingSpeed*Time.deltaTime);

            }
        }

        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovmentTest>() != null)
        {
            isFalling = true;
        }
    }
}
