using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public GameObject clone;
    public GameObject spawner;
    public Transform[] points;
    public float Speed;
    public int index=0;
    private int platFormState;
    private int count;
    public bool isSpawned;
    public GameObject text;

	// Use this for initialization
	void Start () {
        index = 0;
        isSpawned = false;
        this.transform.position = points[index].transform.position;
        index++;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(index);
        if(this.transform.position != points[index].transform.position)
        {

            this.transform.Translate(new Vector3(points[index].position.x - this.transform.position.x, points[index].position.y - this.transform.position.y, points[index].position.z - this.transform.position.z).normalized*Speed*Time.deltaTime);


        } 
        if((this.transform.position.x >= points[index].transform.position.x-0.5 && this.transform.position.x <= points[index].transform.position.x + 0.5)&&
           ( this.transform.position.y >= points[index].transform.position.y - 0.5 && this.transform.position.y <= points[index].transform.position.y + 0.5)&&
           ( this.transform.position.z >= points[index].transform.position.z - 0.5 && this.transform.position.z <= points[index].transform.position.z + 0.5))
        {
            index++;
            if(index> points.Length-1)
            {
                index = 0;
            }

        }



	}
    public void OnDrawGizmos()  //Drawing the Raycasts for walljump in the editor
    { for (int i = 0; i < points.Length;i++) {
            Vector3 r= new Vector3(0,0,0);
            if (i + 1 < points.Length)
            {
                 r = points[i+1].position - points[i ].position;
            }
            else
            {
                r = points[0].position - points[i].position;
            }

            
            Gizmos.DrawRay(points[i].position, r);
        }
    }

    private void OnTriggerEnter(Collider other)
    { }


}
