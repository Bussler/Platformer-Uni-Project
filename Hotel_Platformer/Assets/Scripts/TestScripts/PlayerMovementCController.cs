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
    public bool isGliding;
    public float maxSpeed;
    public float runMultiplier;

    CharacterController playerController;
    private Vector3 moveDirection;
    private Quaternion playerRotation;
    private float storedYValue;
    private float fallmultiplier;
    private float spruenge = 0;
    private bool allowedToJump;
    private float gravityGliding;

    //run
    private float runSpeed = 1;


    void Start()
    {
        playerController = GetComponent<CharacterController>();//Player has to have a charactaercontroller attached in order to make this stuff wörk
        playerRotation = transform.rotation;
        fallmultiplier = 2f;
        gravityGliding = gravity*3;//stores the correct gravity, cuz the gravity will be changed during gliding
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

        if (runSpeed<maxSpeed&&Input.GetButton("Run"))
        {
            runSpeed = runSpeed + runMultiplier*Time.deltaTime;
        }
        if (Input.GetButtonUp("Run"))
        {
            runSpeed = 1;
        }

        //move
        if (playerController.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed*runSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))//jumping
            {
                moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
            }

        }
        else
        {
            if (spruenge < zahlSpruenge && allowedToJump == true&&isGliding==false)//double jumping, no double jumping during gliding
            {
                if (Input.GetButton("Jump"))//jumping
                {
                    moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
                    spruenge++;//count up
                    allowedToJump = false;
                }

            }
        }

        
        if (Input.GetButtonUp("Jump"))//determines, if the button is pressed again, therefore enbling double jumping
        {
            allowedToJump = true;
        }
    

        //betterJump
        if (moveDirection.y<storedYValue)//falling
        {
            //gliding
            if (isGliding==true) //gliding begins, when player is falling for the first time
            {
                Gliding();
                Turn();
                return;
            }
            else
            {
                moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
            }

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

    void Gliding()
    {
        //the player can move in air
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;//calculate a vector/movement with given playerinput
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection.y -= gravityGliding * Time.deltaTime;//adjusting y value with specialized gravity

        playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame

    }
}
