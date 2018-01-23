using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentTest : MonoBehaviour, ITR
{
    public int health;
    private int maxHealth;
    


    public float moveSpeed;
    public float rotateSpeed;
    public float gravity;
    public bool isGrounded;
    public int maxNumberOfPlatforms;
    private int floatingFallSpeed = 0;
    public Transform SpawnPoint; //spawnPoint

    GameObject[] objectArray = new GameObject[0];

    public GameObject[] respawn = new GameObject[10];

    public GameObject SpawnablePlatform;

    public Animator animator;
    private TimeREverse trscript;
    CharacterController playerController;
    private Vector3 moveDirection;
    private Quaternion playerRotation;
    private float storedYValue;
    private float fallmultiplier;
    public bool canBeControlled = true;

    private bool isFloating=false; //bool for floating

    public Vector3 lastMoveDirection;
    private bool dirSet = false;

    public LayerMask mask;

    private GameObject ausgewähltesObject;
    public Camera camera;
    private bool hasObject;

    public CircularBuffer buffer;

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
    public bool hasAbilityScaling;//TODO
    public bool hasAbilityPlatform;
    public bool hasAbilityAusheben;
    public bool hasAbilityTimeReversal;
    #endregion

    public float MinSize;
    public float MaxSize;

    void Start()
    {
        maxHealth = health;
        SpawnPoint = GameObject.Find("SpawnPoint").transform;
        camera = GameObject.FindObjectOfType<Camera>();
        playerController = GetComponent<CharacterController>();//Player has to have a charactaercontroller attached in order to make this stuff wörk
        playerRotation = transform.rotation;
        fallmultiplier = 2f;
        gravityGliding = gravity * 4.5f;//stores the correct gravity, cuz the gravity will be changed during gliding 1.6, 6
        Spawn();
        health = maxHealth;
        buffer = FindObjectOfType<CircularBuffer>();
        trscript = GetComponent<TimeREverse>();
        if (this.transform.childCount > 0)
        {
            Debug.Log("Passt");
            animator = this.transform.GetChild(0).GetComponent<Animator>();
        }
       
    }

    //Movement in update, since we aren't using a rigidbody but a characterController
    void Update()
    {
        storedYValue = transform.position.y;    
        CheckGround();//Checks if player is grounded
        handleFloating();
        if (canBeControlled)
        {
          
           
        }

        calculateMovement(); // calculates the horizontal Movement;

        HandleInput(); // Handles all  other PlayerInput;
        if (isFloating)//only press v once to glide
        {
            Gliding();
        }
        //else
        //{
            if (moveDirection.y < storedYValue && !isFloating)//falling
            {
                this.transform.parent = null;

                moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
            }
            if (!Input.GetButton("Jump") && moveDirection.y > storedYValue && !isFloating)
            {
                moveDirection.y -= gravity * fallmultiplier * Time.deltaTime;
            }
        if (!isFloating) {
            moveDirection.y -= gravity * Time.deltaTime;  //applying gravity;
        }
            playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame 
        
       // }

     
        Turn();


        if (health <= 0)
        {
            Death();
        }

        animator.SetFloat("x", Input.GetAxis("Horizontal"));
        animator.SetFloat("y", Input.GetAxis("Vertical"));

    }

    public void LateUpdate()
    {
        if (hasAbilityAusheben)
        {

            Vector3 vor = new Vector3(this.transform.position.x - camera.transform.position.x, -this.transform.position.y, this.transform.position.z - camera.transform.position.z);
            // Vector3 vor = Vector3.forward;

            if (ausgewähltesObject != null)
            {
                if (this.transform.position.y + (2) - (camera.transform.position.y - (this.transform.position.y + 2)) > this.transform.position.y - transform.lossyScale.y * 0.5f)
                {
                    ausgewähltesObject.transform.position = this.transform.position + new Vector3(vor.x, (2) - (camera.transform.position.y - (this.transform.position.y + 2)), vor.z);
                }
               

            }
        }
    }

    void Death()
    {
      
        SpawnPoint = GameObject.Find("SpawnPoint").transform;
        Spawn();
        health = maxHealth;

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
            isFloating = false;//resetting the value if touching the ground
            floatingFallSpeed = 0;
            animator.SetBool("isGrounded", true);
        }
        else
        {
            
            animator.SetBool("isGrounded", false);
        }
    }

    public void HandleInput() //ganzen Input
    {                                           // Setting the bools where the player is Moving, maybe useful for later
        if(Input.GetAxis("Horizontal") > 0){  
            isMovingLeft = false;
            isMovingRight = true;
            animator.SetBool("right",true);
            animator.SetBool("left", false);
            
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            isMovingLeft = true;
            isMovingRight = false;
            animator.SetBool("right",false);
            animator.SetBool("left", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            isMovingLeft = false;
            isMovingRight = false;
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            isMovingForwards = false;
            isMovingBackwards = true;
            animator.SetBool("back", true);
            animator.SetBool("forward", false);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            isMovingForwards = true;
            isMovingBackwards = false;
            animator.SetBool("back", false);
            animator.SetBool("forward", true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            isMovingForwards = false;
            isMovingBackwards = false;
            animator.SetBool("back", false);
            animator.SetBool("forward", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (hasAbilityJumping)
            {
                Jump();
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
            if (hasAbilityScaling)
            {
                ScalingUp();
            }
        }
        if (Input.GetButtonDown("ScalingDown"))
        {
            if (hasAbilityScaling)
            {
                ScalingDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hasAbilityAusheben)
            {
                //Debug.Log("maus");
                ObjectAuswahl();
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ausgewähltesObject = null;

        }
        if (Input.GetButtonDown("PlatformSpawn") && hasAbilityPlatform)
        {
            SpawnPlatform();
        }

    }

  




       
    
  public void ObjectAuswahl()
{
    // Vector3 vor = Quaternion.AngleAxis(-45, Vector3.up) *new Vector3(this.transform.position.x - camera.transform.position.x, this.transform.position.y - camera.transform.position.y, this.transform.position.z - camera.transform.position.z).normalized*5f;
    //Vector3 vor = Quaternion.Euler(0,45,0)*new Vector3(this.transform.position.x - camera.transform.position.x, this.transform.position.y - camera.transform.position.y, this.transform.position.z - camera.transform.position.z).normalized*5f;
    // Vector3 vor2 = new Vector3(vor.x, -vor.y, vor.z) + vor;

    Ray ray = new Ray(this.transform.position, new Vector3(this.transform.position.x - camera.transform.position.x, 0, this.transform.position.z - camera.transform.position.z));
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
    {
       
        if (hit.collider.gameObject.tag == "Aufhebbar")
        {
            ausgewähltesObject = hit.collider.gameObject;
           // Debug.Log(ausgewähltesObject.name);

        }


    }



}

public void SpawnPlatform()
    {
        //TODO maybe use the storeyYData to spawn enemies when you are falling
        Transform spawnPosition = transform.GetChild(1).transform;
        GameObject p = Instantiate(SpawnablePlatform, new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity)as GameObject;
        
        
            GameObject[] newArray = new GameObject[objectArray.Length + 1];
            for (int i=0;i<objectArray.Length;i++)
            {
                newArray[i] = objectArray[i];
            }
            newArray[newArray.Length - 1] = p;
            objectArray = newArray;
        
        if (objectArray.Length>maxNumberOfPlatforms)
        {
            Destroy(objectArray[0]);
            
            GameObject[] newArray2 = new GameObject[objectArray.Length - 1];
            for (int i=0;i<newArray2.Length;i++)
            {
                newArray2[i] = objectArray[i+1];
            }
            objectArray = newArray2;
    
        }
    
    } 


    public void calculateMovement()
    {
        if (isGrounded )  //normal movement on Ground
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), floatingFallSpeed, Input.GetAxis("Vertical")) * moveSpeed * runSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);
            dirSet = false;
        }
        if (!isGrounded&&isFloating)  //normal movement on Ground
      {
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), floatingFallSpeed, Input.GetAxis("Vertical")) * moveSpeed * runSpeed;//calculate a vector/movement with given playerinput
            moveDirection = transform.TransformDirection(moveDirection);
            dirSet = false;
        }
        if (!isGrounded&&isFloating==false)  // slow changing the movementvector in air when pressing againts movement direction
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
    void handleFloating() {
        if (Input.GetButtonDown("Gliding"))//changed to button down
        {

            if (hasAbilityGliding) {
                // Gliding();
                if (isFloating) {
                    isFloating = false;//deactivate gliding
                    floatingFallSpeed = 0;
                } else {
                    isFloating = true;//activate gliding
                    floatingFallSpeed = -200;
                }
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
        //Debug.Log("isGliding when falling");

        if (moveDirection.y < storedYValue)//falling
        {
            //Debug.Log("isGliding when falling");
            //the player can move in air
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;//calculate a vector/movement with given playerinput
            
            moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection.y = -2* gravityGliding * Time.deltaTime;//adjusting y value with specialized gravity
            
             moveDirection.y -= gravityGliding * Time.deltaTime;//adjusting y value with specialized gravity
            playerController.Move(moveDirection * Time.deltaTime);//making the player move ingame

            //Debug.Log("isGliding after falling");
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
                animator.SetTrigger("jump");
            }
            else
            {
                
                if (isMovingLeft)  //checks if player is moving left and wall is left;
                {
                    Debug.Log("left");
                    if (Physics.Raycast(this.transform.localPosition, transform.TransformDirection(new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z) - this.transform.position), 1.3f, mask.value))
                    {
                        WallJump(4);
                        Debug.Log("Walljump");
                        return;
                    }
                }
                if (isMovingRight)
                {
                    Debug.Log("left");
                    if (Physics.Raycast(this.transform.position,  transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position), 1.3f, mask.value))
                    {
                        WallJump(2);
                        Debug.Log("Walljump");
                        return;
                    }
                }
                if (hasJumped < timesToJump)  //multple Jumps
                {
                    moveDirection.y = jumpSpeed;//setting the y value, therefore making the player jump
                   // Debug.Log(moveDirection.y);
                    hasJumped++;//count up
                                // Debug.Log("doublejump");
                    animator.SetTrigger("jump");
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
        Ray ray = new Ray(this.transform.position, new Vector3(this.transform.position.x - camera.transform.position.x, 0, this.transform.position.z - camera.transform.position.z));
        Vector3 r = transform.TransformDirection(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z) - this.transform.position);
        Vector3 l =transform.TransformDirection( new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z)-this.transform.position);
        //Vector3 vor = transform.TransformVector( Quaternion.Euler(0,-45, -45) * new Vector3(this.transform.position.x - camera.transform.position.x, this.transform.position.y - camera.transform.position.y, this.transform.position.z - camera.transform.position.z));
       // Vector3 vor2 = new Vector3(vor.x, -vor.y, vor.z) + vor;
        Gizmos.DrawRay(this.transform.position,r);
        Gizmos.DrawRay(this.transform.position, l);
        Gizmos.DrawRay(ray);
       // Gizmos.DrawRay(this.transform.position, vor);
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


    public void Spawn()//use this for touching deathzone etc.
    {
        this.transform.position = SpawnPoint.position;
        

        //setting all the inactive deathzones as obstacles active again, maybe we find a better solution here
        for (int i=0;i<respawn.Length;i++)
        {
            if (respawn[i]!=null)
            {
                respawn[i].SetActive(true);
            }
        }
       

    }


    private class MyStatus : TRObject
    {
        public Vector3 myPosition;
        public Quaternion myRotation;
    }

    public void SaveTRObject()
    {
        MyStatus status = new MyStatus();
        status.myPosition = transform.position;
        status.myRotation = transform.rotation;
        trscript.PushTRObject(status);
        //playerRigidbody.isKinematic = false;
    }
    public void LoadTRObject(TRObject trobject)
    {
        MyStatus newStatus = (MyStatus)trobject;
        transform.position = newStatus.myPosition;
        transform.rotation = newStatus.myRotation;
       // playerRigidbody.isKinematic = true;
    }

}
