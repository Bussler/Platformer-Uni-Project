﻿using System.Collections;
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

    private GameObject ausgewähltesObject;
    public Camera camera;
    private bool hasObject;

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
    public float jumpMovement = 4;
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

    public float MinSize;
    public float MaxSize;

    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>();
        playerController = GetComponent<CharacterController>();//Player has to have a charactaercontroller attached in order to make this stuff wörk
        playerRotation = transform.rotation;
        fallmultiplier = 2f;
        gravityGliding = gravity * 2;//stores the correct gravity, cuz the gravity will be changed during gliding
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
            this.transform.parent = null;
          
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
        }
        if (!Input.GetButton("Jump") && moveDirection.y > storedYValue)         
        {
            moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;            
        }        


        moveDirection.y -= gravity * Time.deltaTime;  //applying gravity;
        playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame  
     
        Turn();

 

        if (ausgewähltesObject != null)
        {
           // ausgewähltesObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z);
        }

       
       
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       // camera.gameObject.GetComponent<CameraFollow>().minY = hit.gameObject.transform.position.y;
        //Hier alles rein, wenn was passieren soll, wenn der Spieler etwas berührt;
        if (hit.gameObject.tag == "FallingPlatform")
        {

            hit.gameObject.GetComponent<FallingPlatform>().isFalling = true;
        }


        if (hit.gameObject.tag == "MovingPlatform" )
        {
           
            this.gameObject.transform.parent = hit.transform;
        }
        if (hit.gameObject.tag == "RotatingPlatform")
        {
            if (hit.gameObject.GetComponent<RotatingPlatform>().rotatingDirection.x == 0 && hit.gameObject.GetComponent<RotatingPlatform>().rotatingDirection.z == 0)
            {

                this.gameObject.transform.parent = hit.transform;

            }
           
          
        }

        if (hit.gameObject.tag == "ZählerPlatform")
        {
            if (hit.gameObject.GetComponent<ZaelerPatfrom>().canBeHit == true)
            {
                hit.gameObject.GetComponent<ZaelerPatfrom>().Leben--;
                hit.gameObject.GetComponent<ZaelerPatfrom>().canBeHit = false;
                hit.gameObject.GetComponent<ZaelerPatfrom>().ChangeColor();
            }
        }
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

        if (Input.GetButtonDown("ScalingUp"))
        {
            ScalingUp();
        }
        if (Input.GetButtonDown("ScalingDown"))
        {
            ScalingDown();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("maus");
            ObjectAuswahl();

        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ausgewähltesObject = null;

        }


    }

    public void ObjectAuswahl()
    {
        // Vector3 vor = Quaternion.AngleAxis(-45, Vector3.up) *new Vector3(this.transform.position.x - camera.transform.position.x, this.transform.position.y - camera.transform.position.y, this.transform.position.z - camera.transform.position.z).normalized*5f;
        //Vector3 vor = Quaternion.Euler(0,45,0)*new Vector3(this.transform.position.x - camera.transform.position.x, this.transform.position.y - camera.transform.position.y, this.transform.position.z - camera.transform.position.z).normalized*5f;
       // Vector3 vor2 = new Vector3(vor.x, -vor.y, vor.z) + vor;

        Ray ray = new Ray(this.transform.position,new Vector3(this.transform.position.x-camera.transform.position.x,0,this.transform.position.z-camera.transform.position.z));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            Debug.Log("ray");
            if (hit.collider.gameObject.tag=="Aufhebbar")
            {
                 ausgewähltesObject= hit.collider.gameObject;
                Debug.Log(ausgewähltesObject.name);

            }
              

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
        if (!isGrounded&&!Input.GetButton("Gliding"))  // slow changing the movementvector in air when pressing againts movement direction
        {
            if (Input.GetButton("Run")||runSpeed>1)
            {
                //haven't decided what to do in this case. option1: do nothing like right now(maybe best, its unrealistic to defy all laws of gravity like this) option2: make move possible but I haven't found a solution how to do this and not affect the moved distance
            }
            else
            {
                //moveDirection = new Vector3(Input.GetAxis("Horizontal") * jumpMovement, moveDirection.y, Input.GetAxis("Vertical") * jumpMovement);
               // moveDirection = transform.TransformDirection(moveDirection);      // wenn aktiviert zu starkes bewegen in der luft und walljump funktioniert dann nicht mehr
                dirSet = false;
            }
    
        }
    }


    void ScalingUp()
    {
        if (this.transform.localScale.x > 1 - 0.1 && this.transform.localScale.x < 1 + 0.1)
        {
            this.transform.localScale = new Vector3(MaxSize, MaxSize, MaxSize);
        }else if(this.transform.localScale.x > MinSize-0.1&& this.transform.localScale.x < MinSize + 0.1)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void ScalingDown()
    {

        if (this.transform.localScale.x > 1-0.1&& this.transform.localScale.x < 1 + 0.1)
        {
            this.transform.localScale = new Vector3(MinSize, MinSize, MinSize);
        }
        else if (this.transform.localScale.x > MaxSize - 0.1 && this.transform.localScale.x < MaxSize + 0.1)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
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
        this.transform.parent = null;
        if (canJump)
        {
            if (isGrounded)
            {
                moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
               // Debug.Log(moveDirection.y);
                hasJumped=1;
               // Debug.Log("Jump");                                            
            }
            else
            {
                if (isMovingLeft)  //checks if player is moving left and wall is left;
                {
                    if (Physics.Raycast(this.transform.localPosition, transform.TransformDirection(new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z) - this.transform.position), this.transform.lossyScale.x / 2 + 0.1f, mask.value))
                    {
                        WallJump(4);
                       // Debug.Log("Walljump");
                        return;
                    }
                }
                if (isMovingRight)
                {
                    if (Physics.Raycast(this.transform.position,  transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position), this.transform.lossyScale.x / 2 + 0.1f, mask.value))
                    {
                        WallJump(2);
                        //Debug.Log("Walljump");
                        return;
                    }
                }
                if (hasJumped < timesToJump)  //multple Jumps
                {
                    moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
                    Debug.Log(moveDirection.y);
                    hasJumped++;//count up
                   // Debug.Log("doublejump");
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
        //Vector3 vor = transform.TransformVector( Quaternion.Euler(0,-45, -45) * new Vector3(this.transform.position.x - camera.transform.position.x, this.transform.position.y - camera.transform.position.y, this.transform.position.z - camera.transform.position.z));

        Vector3 vor = new Vector3(this.transform.position.x - camera.transform.position.x, 0, this.transform.position.z - camera.transform.position.z);// Vector3 vor2 = new Vector3(vor.x, -vor.y, vor.z) + vor;
        Gizmos.DrawRay(this.transform.position,r);
        Gizmos.DrawRay(this.transform.position, l);
        Gizmos.DrawRay(this.transform.position, vor);
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
