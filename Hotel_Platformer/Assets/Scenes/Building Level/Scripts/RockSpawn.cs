using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour {

    public GameObject spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float randomNo = Random.Range(0f, 60f);
        if (randomNo < 3f)
        {
            Instantiate(spawn);
        }
	}
}
