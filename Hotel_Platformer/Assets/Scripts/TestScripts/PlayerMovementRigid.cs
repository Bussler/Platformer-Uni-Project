using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigid : MonoBehaviour {

    public float speed;
    public float jumpspeed;
    private Rigidbody playerRigidBody;
    private Vector3 velocity;

	void Start () {
        playerRigidBody = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            jump();
        }
	}

    private void FixedUpdate()
    {
        //if we use this, we have to make sure that the player stands on the ground first
        float moveHorizontal = Input.GetAxis("Horizontal");
        velocity.x = moveHorizontal * speed;

        float moveVertical = Input.GetAxis("Vertical");
        velocity.z = moveVertical * speed;

        velocity.y = playerRigidBody.velocity.y;

        playerRigidBody.velocity = transform.TransformDirection(velocity);
    }

    void jump()
    {
        playerRigidBody.AddForce(Vector3.up * jumpspeed);
    }

    
}
