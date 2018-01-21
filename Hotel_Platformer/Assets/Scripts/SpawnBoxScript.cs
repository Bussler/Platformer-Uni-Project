using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxScript : MonoBehaviour {

    public Transform top;
    public GameObject box;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==box)
        {
            Debug.Log("Box detected");
            box.transform.position = top.position;
            //box.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        }
    }

}
