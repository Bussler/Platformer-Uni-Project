﻿using System.Collections;
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
    public bool wallJump;
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
            t.transform.GetChild(0).GetComponent<TextMesh>().color = Color.black;//changing color
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
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "Giding learned. Press 'V' while in air to glide";
            }
            if (gliding==false)
            {
                playerScript.hasAbilityGliding = false;
             //   t.transform.GetChild(0).GetComponent<TextMesh>().text = "You can't glide anymore!";
            }
            if (wallJump == false) {
                playerScript.hasAbilityWallJump = false;
                //   t.transform.GetChild(0).GetComponent<TextMesh>().text = "You can't glide anymore!";
            }
            if (wallJump == true) {
                playerScript.hasAbilityWallJump = true;
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "Walk next to a wall and walk sideways against it and jump";
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
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "PlatformSpwan learned. Press 'F' to spawn up to 3 Plazforms!";
            }
            if (aufheben==true)
            {
                playerScript.hasAbilityAusheben = true;
                t.transform.GetChild(0).GetComponent<TextMesh>().text = "Grabbing learned. LeftClick to grab a box, Rightclick to let it fall down!";
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
