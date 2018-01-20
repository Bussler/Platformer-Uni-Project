using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnBuilding : MonoBehaviour {
    public Transform toBeCloned1;
    public Transform toBeCloned2;
    public GameObject[] array;


	// Use this for initialization
	void Start () {
        array = new GameObject[100];
        for(int i=0; i<100; i++)
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 0f);
            float randomZ = Random.Range(-100f, 100f);
            float randomObj = Random.Range(0f, 1f);

            if (randomObj < .5f)
            {
                Instantiate(toBeCloned1, new Vector3(randomX, randomY, randomZ), new Quaternion(0f, 0f, 0f, 0f));
            } else
            {
                Instantiate(toBeCloned2, new Vector3(randomX, randomY, randomZ), new Quaternion(0f, 0f, 0f, 0f));
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
