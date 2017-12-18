using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    public float rotateSpeed;
    public float gravity;
    public float zahlSpruenge;

    CharacterController playerController;
    private Vector3 moveDirection;
    private Quaternion playerRotation;
    private float storedYValue;
    private float fallmultiplier;
    private float spruenge = 0;
    private bool allowedToJump;


    void Start()
    {
        playerController = GetComponent<CharacterController>();//Player has to have a charactaercontroller attached in order to make this stuff wörk
        playerRotation = transform.rotation;
        fallmultiplier = 2f;
    }

    //Movement in update, since we aren't using a rigidbody but a characterController
    void Update()
    {
        storedYValue = transform.position.y;
        if (playerController.isGrounded)
        {
            spruenge = 0;
            allowedToJump = false;
        }

        //move
        if (playerController.isGrounded)//doublejumps not yet implemented, maybe we have to change this because we can't do anything in air
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))//jumping
            {
                moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
            }

        }
        else
        {
            if (spruenge < zahlSpruenge && allowedToJump == true)//double jumping
            {
                if (Input.GetButton("Jump"))//jumping
                {
                    moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
                    spruenge++;//count up
                }

            }
        }

        
        if (Input.GetButtonUp("Jump"))//determines, if the button is pressed again, therefore enbling double jumping
        {
            allowedToJump = true;
        }
    


        if (moveDirection.y<storedYValue)//falling
        {
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
        }
        else if(!Input.GetButton("Jump")&&moveDirection.y>storedYValue)
        {
            moveDirection.y-= gravity * fallmultiplier * Time.deltaTime;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame

        Turn();

    }

    void Turn()//turns the player with mouseInput, just like in the tutorial
    {
        if (Mathf.Abs(Input.GetAxis("Mouse X"))>0)//es ist ein input gegeben
        {
            playerRotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X")*rotateSpeed*Time.deltaTime,Vector3.up);
        }
        transform.rotation = playerRotation;
    }
}
