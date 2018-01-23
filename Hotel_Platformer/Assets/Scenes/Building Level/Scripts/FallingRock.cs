using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour {

    private GameObject player;
    public GameObject fracture;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        float randomX = Random.Range(-2f, 2f);
        float randomZ = Random.Range(1.5f, 10f);
        transform.position = new Vector3(player.transform.position.x+randomX, player.transform.position.y + 15, player.transform.position.z+randomZ);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 pos = this.transform.position;
        Instantiate(fracture, transform);
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerMovmentTest>().health--;
        }
        Destroy(gameObject);
    }

}
