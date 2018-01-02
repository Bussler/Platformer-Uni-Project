using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform followedObject; //object to follow, in this case the player
    private Vector3 toPosition;
    private float maxDistanceToPlayerUp = 5;
    private float maxDistanceToPlayerDown = -5;
    public float turnSpeed;
    private float savedDisstanceAway;
    private float resetTime=1f;
    private bool turnupdownallowed = true;

    public LayerMask mask;
    
    public void Start()
    {
        savedDisstanceAway = distanceAway;
    }

    


    private void LateUpdate()//is called after update, so when the player has already moved
    {
       
        SetDistance();
        TurnUpDown();//turns up and down by changing the distanceUp var while still making the camera looking at the player
       
            toPosition = followedObject.position + Vector3.up * distanceUp - followedObject.forward * distanceAway;//sets the position of the camer behind the player
         transform.position = Vector3.Lerp(transform.position, toPosition, smooth); //sets the camera behind the player. lerp=smooth following
        
        transform.LookAt(followedObject);

        if(transform.position.y < 1)
        {
            this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
        }
      


    }

    public void TurnUpDown()
    {
        if (turnupdownallowed)
        {
            if (Mathf.Abs(Input.GetAxis("Mouse Y")) > 0)
            {
                if (distanceUp < maxDistanceToPlayerUp && distanceUp > maxDistanceToPlayerDown)
                {
                    distanceUp += -1 * (Input.GetAxis("Mouse Y")) * turnSpeed * Time.deltaTime;
                }
                else if (distanceUp >= maxDistanceToPlayerUp)
                {
                    if (Input.GetAxis("Mouse Y") > 0)
                    {
                        distanceUp += -1 * (Input.GetAxis("Mouse Y")) * turnSpeed * Time.deltaTime;
                    }
                }
                else if (distanceUp <= maxDistanceToPlayerDown)
                {
                    if (Input.GetAxis("Mouse Y") < 0)
                    {
                        distanceUp += -1 * (Input.GetAxis("Mouse Y")) * turnSpeed * Time.deltaTime;
                    }
                }
                /** welp, this stuff does not work properly, it bugs if I jump when the camera is under the player and the player is on the teleported platform
                //boundaries
                if(followedObject.position.y-(transform.position.y)>2)
                {
                    distanceUp = distanceUp+0.1f;
                }
                else
                {
                    if (followedObject.position.y + (transform.position.y) > 9)
                    {
                        distanceUp = distanceUp - 0.1f;
                    }
                    else
                    {
                        distanceUp += -1 * (Input.GetAxis("Mouse Y")) * turnSpeed * Time.deltaTime;
                    }
                    
                }
                */

            }
        }
    }

    public void OnDrawGizmos()  //Drawing the Raycasts 
    {
     
        Gizmos.DrawRay(this.transform.position, followedObject.transform.position - this.transform.position);
        Gizmos.DrawRay(this.transform.position, -(followedObject.transform.position - this.transform.position).normalized);
    }



    public void SetDistance()
    {


        if (Physics.Raycast(this.transform.position, followedObject.transform.position - this.transform.position, (followedObject.transform.position - this.transform.position).magnitude, mask.value))
        {
            distanceAway -= 10 * Time.deltaTime;
            resetTime = 1f;
            Debug.Log("hit");
        }
        else
        {
            Debug.Log("miss");
            if (!Physics.Raycast(this.transform.position, -(followedObject.transform.position - this.transform.position).normalized, 0.5f, mask.value))
            {
                Debug.Log("hinten frei");
                resetTime -= Time.deltaTime;

                if (resetTime <= 0)
                {

                    if (distanceAway < savedDisstanceAway)
                    {
                        distanceAway += 10 * Time.deltaTime;
                    }
                    if (distanceAway > savedDisstanceAway)
                    {
                        distanceAway = savedDisstanceAway;
                    }

                }


            }
            else
            {
                resetTime = 1f;
            }
        }
    }
}
