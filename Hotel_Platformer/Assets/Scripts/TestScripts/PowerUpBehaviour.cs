using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour {

    public bool run;
    public bool doubleJump;
    public bool gliding;
    public bool jumping;

    private PlayerMovmentTest playerScript;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Player")//collision with the player
        {
           playerScript=other.gameObject.GetComponent<PlayerMovmentTest>();

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
            if (jumping==true)
            {
                playerScript.hasAbilityJumping = true;
            }

            Destroy(gameObject);
        }
    }

}
