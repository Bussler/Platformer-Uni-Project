using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrac : MonoBehaviour {

    public bool isWon;

	// Use this for initialization
	void Start () {
        isWon = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fracture")
        {
            Destroy(other.gameObject);
        }
    }
}
