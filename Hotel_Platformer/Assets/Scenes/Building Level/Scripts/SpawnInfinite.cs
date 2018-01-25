using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInfinite : MonoBehaviour {
    public GameObject spawner;
    public GameObject clone;
    public GameObject lights;
    public GameObject spawn;
    public GameObject light;
    public GameObject final;
    public float uprising;
    public bool isCloned;

    private bool lastBuild = false;
    private float formerY;
    private GameObject obj;
    private float count = 0;


	// Use this for initialization
	void Start () {
        isCloned = false;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isCloned == false && count<10)
        {
            isCloned = true;
            obj = Instantiate(clone, new Vector3(this.transform.position.x, transform.position.y, transform.position.z+12f), Quaternion.identity);
            obj.GetComponent<SpawnInfinite>().count = count + 1;
            Debug.Log(obj.GetComponent<SpawnInfinite>().count);
            
               
            
            
        } else if (other.tag == "Player" && this.isCloned == true) 
        {
            isCloned = false;
            Destroy(obj);   
            
        }
        if (other.tag == "Player" && count == 10 )
        {
            Destroy(GameObject.FindGameObjectWithTag("KILLSPAWN"));
            Instantiate(final, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 12f), Quaternion.identity);
            /* float randomX = Random.Range(transform.position.x - 15f, transform.position.x + 15f);
            Vector3 pos = other.transform.position;
            Instantiate(light, new Vector3(randomX, pos.y+5, pos.z + 15), Quaternion.identity);
            Instantiate(spawn, new Vector3(randomX, pos.y, pos.z + 15), Quaternion.identity);
            lastBuild = true;*/ // Hab ich
        }

    }


}
