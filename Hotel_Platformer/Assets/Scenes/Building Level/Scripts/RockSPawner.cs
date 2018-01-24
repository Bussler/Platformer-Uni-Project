using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSPawner : MonoBehaviour {

    public GameObject spawn;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = player.transform.position;
        float randomNo = Random.Range(0f, 60f);
        if (randomNo < 2.5f)
        {
            if (player.GetComponent<PlayerMovmentTest>().moveSpeed != 0)
            {
                Instantiate(spawn, new Vector3(transform.position.x + Random.Range(-3f, 3f), transform.position.y + 15f, transform.position.z + 15f), Quaternion.identity);
            } else
            {
                Instantiate(spawn, new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y + 15f, transform.position.z ), Quaternion.identity);
            }
        }
    }
}
