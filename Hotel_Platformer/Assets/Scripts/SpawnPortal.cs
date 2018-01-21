using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour {

    public GameObject portal;
    public GameObject box;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==box)
        {
            portal.SetActive(true);
        }
    }
}
