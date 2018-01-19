using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEnemyController : MonoBehaviour {

    public Transform target;
    public float flyingHeight = 3f;     
    public float activeDistance = 25f;   //the radius this object gets active (before the trigger)
    public float impulseForce = 1f;
    private Rigidbody rb;
    private float earlierDistance;
    private bool isInTrigger = false;

    void Start() { //Get the rigidbody of this object
        rb = this.GetComponent<Rigidbody>();
    }


    void FixedUpdate() {
        //Get the distance between player and this object
        Vector3 distanceInVector = target.transform.position - transform.position;
        float distance = Mathf.Sqrt(Mathf.Pow(distanceInVector.x, 2) + Mathf.Pow(distanceInVector.z, 2));
        //when not in the Trigger
        if (!isInTrigger) {
            //distance between player and this obejct < activeDistance ?
            if (Mathf.Abs(distance) < activeDistance) {
                if (earlierDistance > activeDistance) {  //did we just move into the getActiveZone ?
                    moveUp();
                }
                //freeze the position of the object & set isKinematic & use LookAt, to floow the player
                rb.constraints = RigidbodyConstraints.FreezePosition;
                rb.isKinematic = true;
                this.transform.LookAt(target);
            } else {
                //set earlierDistance and deactivate the position freeze & isKinematic 
                earlierDistance = distance;
                rb.constraints = RigidbodyConstraints.None;
                rb.isKinematic = false;
            }
        } else {
            //void
        }

    }

    void moveUp() {
        if (this.transform.position.y < flyingHeight) {    //if we are below the flyingHeigt in worldSpace, then the object should translate to this height
            transform.Translate(0, 1 * Time.deltaTime * 4, 0, Space.World);
            Debug.Log("hi");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //deactivate position freeze, isKinematic
            isInTrigger = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.isKinematic = false;
            //calculate Vector 3 towards the player & add 1.1 towards y, so that this hits the middle of the player
            Vector3 toPlayer = (target.transform.position - transform.position);
            toPlayer.y += 1.1f;
            //applay an Impulse(worked best). impulseForce does not change that much. Mass influences the speed better
            rb.AddForce(toPlayer * impulseForce, ForceMode.Impulse);

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            //reset to normal
            isInTrigger = false;
            rb.isKinematic = true;
        }
    }
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            //respawn
            col.gameObject.GetComponent<PlayerMovmentTest>().health--;
        }
    }
}


