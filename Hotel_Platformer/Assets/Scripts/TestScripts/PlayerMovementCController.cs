using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    CharacterController playerController;
    private Vector3 moveDirection;



    void Start()
    {
        playerController = GetComponent<CharacterController>();//Player has to have a charactaercontroller attached in order to make this stuff wörk
    }

    //Movement in update, since we aren't using a rigidbody but a characterController
    void Update()
    {

        if (playerController.isGrounded)//doublejumps not yet implemented, maybe we have to change this because we can't do anything in air
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))//jumping
            {
                moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame
    }
}
