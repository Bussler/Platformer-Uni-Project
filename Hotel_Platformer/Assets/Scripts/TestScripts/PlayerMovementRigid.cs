using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigid : MonoBehaviour {

    public float speed;
    public float jumpspeed;
    public float rotateSpeed;
    private Rigidbody playerRigidBody;
    private Vector3 velocity;
    private Quaternion playerRotation;

    private float fallMultiplier= 2.5f;
    public float lowJumpMultiplier = 2f;


    void Start () {
        playerRigidBody = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        playerRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        Turn();
	}

    private void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        velocity.x = moveHorizontal * speed;

        float moveVertical = Input.GetAxis("Vertical");
        velocity.z = moveVertical * speed;

        velocity.y = playerRigidBody.velocity.y;

        playerRigidBody.velocity = transform.TransformDirection(velocity);

        if (Input.GetButton("Jump"))
        {
            jump();
        }
    }

    void jump()
    {
        playerRigidBody.AddForce(Vector3.up * jumpspeed);
        //better jump
        if (playerRigidBody.velocity.y < 0)//falling
        {
            playerRigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRigidBody.velocity.y > 0 && Input.GetAxisRaw("Jump") == 0)//holding spacebar for higher jumps, shorter jumps
        {
            playerRigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Turn()//turns the player with mouseInput, just like in the tutorial
    {
        if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0)//es ist ein input gegeben
        {
            playerRotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, Vector3.up);
        }
        transform.rotation = playerRotation;
    }


}
