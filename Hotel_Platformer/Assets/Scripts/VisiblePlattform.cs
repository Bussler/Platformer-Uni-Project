using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisiblePlattform : MonoBehaviour {
    public bool isInvisible;
    public bool canPassThrough;


	// Use this for initialization
	void Start () {

        if (isInvisible==true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (canPassThrough==true)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }

	}
	
}
