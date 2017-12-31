using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentTest : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float rotateSpeed;
    public float gravity;
    
    public bool isGliding;
    public float maxSpeed;
    public float runMultiplier;
    public bool isGrounded;
    public bool canJump;

    CharacterController playerController;
    private Vector3 moveDirection;
    private Quaternion playerRotation;
    private float storedYValue;
    private float fallmultiplier;
    public float timesToJump = 2;
    public float hasJumped=0;
    private float gravityGliding;


    public bool isMovingForwards;
    public bool isMovingBackwards;
        public bool isMovingRight;
    public bool isMovingLeft;
    



    //run
    private float runSpeed = 1;


    void Start()
    {
        playerController = GetComponent<CharacterController>();//Player has to have a charactaercontroller attached in order to make this stuff wörk
        playerRotation = transform.rotation;
        fallmultiplier = 2f;
        gravityGliding = gravity * 3;//stores the correct gravity, cuz the gravity will be changed during gliding
    }

    //Movement in update, since we aren't using a rigidbody but a characterController
    void Update()
    {

        storedYValue = transform.position.y;
        CheckGround();


        calculateMovement();
        HandleInput();



      

        if (moveDirection.y < storedYValue)//falling
        {
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
        }
        if (!Input.GetButton("Jump") && moveDirection.y > storedYValue)
        {
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
            
        }






        
        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame
        
        Turn();

    }

    public void CheckGround()
    {

        isGrounded = playerController.isGrounded;
        if (isGrounded)
        {
            canJump = true;
            hasJumped = 0;
        }
    }

    public void HandleInput() //ganzen Innput
    {
        if(Input.GetAxis("Horizontal") > 0){
            isMovingLeft = false;
            isMovingRight = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            isMovingLeft = true;
            isMovingRight = false;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            isMovingLeft = false;
            isMovingRight = false;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            isMovingForwards = false;
            isMovingBackwards = true;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            isMovingForwards = true;
            isMovingBackwards = false;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            isMovingForwards = false;
            isMovingBackwards = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButton("Gliding"))
        {
            Gliding();
        }

        if (Input.GetButton("Run"))
        {
            Run();
        }
        if (Input.GetButtonUp("Run"))
        {
            runSpeed = 1;
        }

    }

    public void calculateMovement()
    {
        // Debug.Log("H" + Input.GetAxis("Horizontal"));
        // Debug.Log("V" + Input.GetAxis("Vertical"));
        if (isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * runSpeed;//calculate a vector/movement with given playerinput

            moveDirection = transform.TransformDirection(moveDirection);


        }
        if (!isGrounded)
        {
             //leichtes dagegebsteuern in der Luft




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

    void Gliding()
    {
        if (moveDirection.y < storedYValue)//falling
        {
            //the player can move in air
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection.y -= gravityGliding * Time.deltaTime;//adjusting y value with specialized gravity

            playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame


        }
       



    }

    public void Jump()
    {
        if (canJump)
        {
            if (isGrounded)
            {

                moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
                Debug.Log(moveDirection.y);
                hasJumped=1;
                Debug.Log("Jump");
              
               
                

            }
            else
            {
                if (isMovingLeft)
                {
                    if (Physics.Raycast(this.transform.localPosition, transform.TransformDirection(new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z) - this.transform.position), this.transform.lossyScale.x / 2 + 0.1f, 1))
                    {
                        WallJump(4);
                        Debug.Log("Walljump");
                        return;

                    }

                }
                if (isMovingRight)
                {
                    if (Physics.Raycast(this.transform.position,  transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position), this.transform.lossyScale.x / 2 + 0.1f, 1))
                    {
                        WallJump(2);
                        Debug.Log("Walljump");
                        return;

                    }

                }


                if (hasJumped < timesToJump)
                {
                    moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
                    Debug.Log(moveDirection.y);
                    hasJumped++;//count up
                    Debug.Log("doublejump");

                }
                else
                {
                    canJump = false;
                }

            }
        }

    }

    public void OnDrawGizmos()
    {

        Vector3 r = transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position);
        Vector3 l =transform.TransformDirection( new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z)-this.transform.position);
        Gizmos.DrawRay(this.transform.position,r);
        Gizmos.DrawRay(this.transform.position, l);
    }

    public void WallJump(int direction)
    {
        if (direction == 4)// gleice problem wie bei bweegung in der luft;
        {
            // this.transform.Translate(new Vector3(jumpSpeed, jumpSpeed, 0));
            moveDirection.y = moveDirection.y + jumpSpeed*1.5f;
            moveDirection.x =  + jumpSpeed*0.8f;
            moveDirection.z = 0;
            moveDirection = transform.TransformDirection(moveDirection);

        }

        if (direction == 2)// gleice problem wie bei bweegung in der luft;
        {
            // this.transform.Translate(new Vector3(jumpSpeed, jumpSpeed, 0));
            moveDirection.y = moveDirection.y + jumpSpeed * 1.5f;
            moveDirection.x =  - jumpSpeed * 0.8f;
            moveDirection.z = 0;
            moveDirection = transform.TransformDirection(moveDirection);

        }

    }

    public void Run()
    {
        if (runSpeed < maxSpeed )
        {
            runSpeed = runSpeed + runMultiplier * Time.deltaTime;
        }
      

    }




}
