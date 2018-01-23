using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTrigger : MonoBehaviour {

    public GameObject wand;
    public GameObject Level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            wand.GetComponent<MeshRenderer>().enabled = false;
            wand.GetComponent<Collider>().enabled = false;
            Level.SetActive(true);
        }    
    }



}
