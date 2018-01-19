using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {

    private PlayerMovmentTest pScript;
  

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Player")
            {
             other.gameObject.GetComponent<PlayerMovmentTest>().health--;
               
                Debug.Log("DEath");
              
                other.gameObject.GetComponent<PlayerMovmentTest>().Spawn();
            }
           // pScript = other.gameObject.GetComponent<PlayerMovmentTest>();
           // pScript.Spawn();
            }
    }


