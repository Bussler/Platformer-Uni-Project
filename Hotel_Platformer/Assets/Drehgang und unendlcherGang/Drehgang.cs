using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drehgang : MonoBehaviour {
    public GameObject player;
    int state = 1;
    public Transform spawn1;
    public Transform spawn2;
    public GameObject[] walls;
    GameObject a;
    GameObject b;
    GameObject c;
    GameObject d;
    GameObject e;
    GameObject f;



    // Use this for initialization
    void Start () {
        a= Instantiate(walls[0], spawn1.transform.position, spawn1.transform.rotation);
       b= Instantiate(walls[1], spawn2.transform.position, spawn2.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("" + state);
       // Debug.Log("" + player.transform.eulerAngles);
        if (state == 1)
        {
            if ((player.transform.rotation.eulerAngles.y> 180 && player.transform.rotation.eulerAngles.y <360) )
            {
                Destroy(a);
                
               c= Instantiate(walls[2], spawn1.transform.position, spawn1.transform.rotation);
                state = 2;
            }
        }
        if (state == 2)
        {
            if ((player.transform.rotation.eulerAngles.y > 0 && player.transform.rotation.eulerAngles.y < 180))
            {
                Destroy(b);
               d= Instantiate(walls[0], spawn2.transform.position, spawn2.transform.rotation);
                state = 3;
            }
        }
        if (state == 3)
        {
            if ((player.transform.rotation.eulerAngles.y > 180 && player.transform.rotation.eulerAngles.y < 360))
            {
                Destroy(c);
               e= Instantiate(walls[1], spawn1.transform.position, spawn1.transform.rotation);
                state = 4;
            }
        }


    }
}
