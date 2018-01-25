using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWin : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerFrac>().isWon==true)
        {
            // TODO WAS MAN MACHEN SOLL WENN DAS LEVEL ZU ENDE IST
            Debug.Log("WIN");
        }
        else if (other.tag == "Player" && other.gameObject.GetComponent<PlayerFrac>().isWon == false)
        {
            GameObject[] kills = GameObject.FindGameObjectsWithTag("KILLME");
            for(int i=0; i<kills.Length; i++)
            {
                Destroy(kills[i].gameObject);
                GameObject.FindGameObjectWithTag("STARTPLATFORM").GetComponent<SpawnInfinite>().isCloned = false;
            }
        }
        // pScript = other.gameObject.GetComponent<PlayerMovmentTest>();
        // pScript.Spawn();
    }
}

