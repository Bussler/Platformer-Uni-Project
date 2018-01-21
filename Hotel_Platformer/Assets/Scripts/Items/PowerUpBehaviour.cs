using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBehaviour : MonoBehaviour {

    public bool run;
    public bool doubleJump;
    public bool gliding;
    public bool jumping;
    public bool platformSpawn;
    public bool aufheben;

    private PlayerMovmentTest playerScript;

    public GameObject text;
    public GameObject t;
    private void Start()
    {
         
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag=="Player")//collision with the player
        {
            
            text.AddComponent<TextMesh>();
            // text.transform.parent = GameObject.Find("LebenCanvas").transform;
         t= Instantiate(text, this.transform.position,Quaternion.identity);
            t.transform.position = this.transform.position+Vector3.up;
            t.transform.LookAt(GameObject.FindObjectOfType<Camera>().transform);
            t.transform.GetChild(0).GetComponent<TextMesh>().fontSize = 10;
            t.transform.GetChild(0).GetComponent<TextMesh>().characterSize = 0.2f;
            Debug.Log("Power");
            playerScript =other.gameObject.GetComponent<PlayerMovmentTest>();
            

            //enable abilities, this could also be used to disable abilities
            if (run==true)
            {
                playerScript.hasAbilityRunning = true;
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "Running learned. Press 'C' to run";
            }
            if (doubleJump == true)
            {
                playerScript.timesToJump++;
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "Doublejumping learned. Press 'Space' \nwhile in air to doublejump";
            }
            if (gliding==true)
            {
                playerScript.hasAbilityGliding = true;
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "Giding learned. Press 'F' while in air to glide";
            }
            if (gliding==false)
            {
                playerScript.hasAbilityGliding = false;
            }
            if (jumping==true)
            {
                playerScript.hasAbilityJumping = true;
            }

            Invoke("Destroytext", 3);
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;

            if (platformSpawn==true)
            {
                playerScript.hasAbilityPlatform = true;
            }
            if (aufheben==true)
            {
                playerScript.hasAbilityAusheben = true;
            }

            Destroy(gameObject);

        }
    }

    void Destroytext()
    {
        Destroy(t);
        Destroy(gameObject);
    }
}
