using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRisingPlatform : MonoBehaviour {

    public GameObject spawn;
    public GameObject light;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Collision hit!");
            Vector3 pos = collision.transform.position;
            Instantiate(light, new Vector3(pos.x, pos.y, pos.z + 12), Quaternion.identity);
            Instantiate(spawn, new Vector3(pos.x, pos.y-10, pos.z + 12), Quaternion.identity);
        }
    }
}
