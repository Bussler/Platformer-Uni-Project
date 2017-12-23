using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public float x;
    public float y;
    public float z;
    private Vector3 teleportKoordinaten;

    private void Start() {
        teleportKoordinaten = new Vector3(x, y, z);
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {    //Wenn ein Spieler hindurchläuft, dann wird er teleportiert
			other.transform.position = teleportKoordinaten;
		}
	}
}
