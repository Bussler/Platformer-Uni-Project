using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentTest : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public float gravity;
    public bool isGrounded;

    CharacterController playerController;
    private Vector3 moveDirection;
    private Quaternion playerRotation;
    private float storedYValue;
    private float fallmultiplier;

    public Vector3 lastMoveDirection;
    private bool dirSet = false;

    public LayerMask mask;

    #region GlidingVariables
    private float gravityGliding;
    #endregion


    #region RunningVariables
    public float maxSpeed;
    public float runMultiplier;
    private float runSpeed = 1;
    #endregion;

    #region JumpingVariables
    public float jumpSpeed;
    public float timesToJump = 2;
    private bool canJump;
    private float hasJumped = 0;
    #endregion

    #region DirectionBools
    private bool isMovingForwards;
    private bool isMovingBackwards;
    private bool isMovingRight;
    private bool isMovingLeft;
    #endregion

    #region Abilities
    public bool hasAbilityGliding;
    public bool hasAbilityRunning;
    public bool hasAbilityWallJump;
    public bool hasAbilityJumping;
    #endregion

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
        CheckGround();//Checks if player is grounded
        calculateMovement(); // calculates the horizontal Movement;
        HandleInput(); // Handles all  other PlayerInput;
        if (moveDirection.y < storedYValue)//falling
        {
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
        }
        if (!Input.GetButton("Jump") && moveDirection.y > storedYValue)         
        {
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;            
        }        


        moveDirection.y -= gravity * Time.deltaTime;  //applying gravity;
        playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame      
        Turn();
       
    }

    public void CheckGround()
    {
        isGrounded = playerController.isGrounded;
        if (isGrounded)
        {
            canJump = true;
            hasJumped = 0; //setting the times the player has jumped to 0 when on ground;
        }
    }

    public void HandleInput() //ganzen Input
    {                                           // Setting the bools where the player is Moving, maybe useful for later
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
            if (hasAbilityJumping)
            {
                Jump();
            }
        }
        if (Input.GetButton("Gliding"))
        {
            if (hasAbilityGliding)
            {
                Gliding();
            }
        }
        if (Input.GetButton("Run"))
        {
            if (hasAbilityRunning)
            {
                Run();
            }
        }
        if (Input.GetButtonUp("Run"))
        {
            runSpeed = 1;
        }
    }

    public void calculateMovement()
    {
        if (isGrounded)  //normal movement on Ground
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * runSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);
            dirSet = false;
        }
        if (!isGrounded)  // slow changing the movementvector in air when pressing againts movement direction
        {

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
                if (isMovingLeft)  //checks if player is moving left and wall is left;
                {
                    if (Physics.Raycast(this.transform.localPosition, transform.TransformDirection(new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z) - this.transform.position), this.transform.lossyScale.x / 2 + 0.1f, mask.value))
                    {
                        WallJump(4);
                        Debug.Log("Walljump");
                        return;
                    }
                }
                if (isMovingRight)
                {
                    if (Physics.Raycast(this.transform.position,  transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position), this.transform.lossyScale.x / 2 + 0.1f, mask.value))
                    {
                        WallJump(2);
                        Debug.Log("Walljump");
                        return;
                    }
                }
                if (hasJumped < timesToJump)  //multple Jumps
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

    public void OnDrawGizmos()  //Drawing the Raycasts for walljump in the editor
    {
        Vector3 r = transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position);
        Vector3 l =transform.TransformDirection( new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z)-this.transform.position);
        Gizmos.DrawRay(this.transform.position,r);
        Gizmos.DrawRay(this.transform.position, l);
    }

    public void WallJump(int direction) //1 front,  2 right,  3 back,  4 left
    {
        if (direction == 4)
        {
            moveDirection.y = moveDirection.y + jumpSpeed*1.5f;
            moveDirection.x =  + jumpSpeed*0.8f;
            moveDirection.z = 0;
            moveDirection = transform.TransformDirection(moveDirection);
        }
        if (direction == 2)
        {
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
