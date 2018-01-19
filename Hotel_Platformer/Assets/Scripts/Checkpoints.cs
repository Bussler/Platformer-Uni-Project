using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoints : MonoBehaviour {
  
   public  int Thisindex;
    public GameObject particle;
    public GameObject text;
    GameObject n;
    GameObject k;
    private bool hasChecked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasChecked)
        {
            if (other.tag == "Player")
            {
                hasChecked = true;
                Debug.Log("Checkpoint");
                other.gameObject.GetComponent<PlayerMovmentTest>().SpawnPoint = this.transform;
                n = Instantiate(particle, this.transform.position, Quaternion.identity);
                k = Instantiate(text, this.transform.position, Quaternion.identity);
                Invoke("Destroythis", 2);
                k.transform.LookAt(FindObjectOfType<Camera>().transform);
            }
        }
    }


    void Destroythis()
    {
        Destroy(n);
        Destroy(k);
    }
}
