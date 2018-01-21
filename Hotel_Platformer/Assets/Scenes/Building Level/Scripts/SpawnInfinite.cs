using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInfinite : MonoBehaviour {

    public GameObject clone;
    public bool isCloned;
    private GameObject obj;
    private float formerY;
    public float uprising;
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
        if (other.tag == "Player" && isCloned == false && count<20)
        {
            isCloned = true;
            obj = Instantiate(clone, new Vector3(this.transform.position.x, transform.position.y, transform.position.z+12f), Quaternion.identity);
            obj.GetComponent<SpawnInfinite>().count = count + 1;
            
        } else if (other.tag == "Player" && isCloned == true)
        {
            isCloned = false;
            Destroy(obj);
            
        }
    }

    
}
