using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWin : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.transform.GetComponent<PlayerFrac>().isWon==true)
        {
            // TODO WAS MAN MACHEN SOLL WENN DAS LEVEL ZU ENDE IST
            Debug.Log("WIN");
        }
        // pScript = other.gameObject.GetComponent<PlayerMovmentTest>();
        // pScript.Spawn();
    }
}

