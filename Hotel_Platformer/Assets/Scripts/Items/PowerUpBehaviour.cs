using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour {

    public bool run;
    public bool doubleJump;
    public bool gliding;
    public bool jumping;
    public bool platformSpawn;
    public bool aufheben;

    private PlayerMovmentTest playerScript;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag=="Player")//collision with the player
        {
            Debug.Log("Power");
            playerScript =other.gameObject.GetComponent<PlayerMovmentTest>();

            //enable abilities, this could also be used to disable abilities
            if (run==true)
            {
                playerScript.hasAbilityRunning = true;
            }
            if (doubleJump == true)
            {
                playerScript.timesToJump++;
            }
            if (gliding==true)
            {
                playerScript.hasAbilityGliding = true;
            }
            if (gliding==false)
            {
                playerScript.hasAbilityGliding = false;
            }
            if (jumping==true)
            {
                playerScript.hasAbilityJumping = true;
            }
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

}
