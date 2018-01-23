using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateLobby : MonoBehaviour {

    public GameObject Lobby;
    public GameObject wand;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Lobby.SetActive(false);
            wand.SetActive(true);
        }
    }
}
