using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
  
   public  int Thisindex;

  

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Debug.Log("Checkpoint");
            other.gameObject.GetComponent<PlayerMovmentTest>().SpawnPoint = this.transform;

        }
    }
}
