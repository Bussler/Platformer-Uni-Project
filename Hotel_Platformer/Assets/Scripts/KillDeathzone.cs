using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDeathzone : MonoBehaviour {

    public GameObject deathzone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Player registered");

            //destroy deathzone
                deathzone.gameObject.SetActive(false);

            
        }
    }

}
