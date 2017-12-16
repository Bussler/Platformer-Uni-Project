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

    private void LateUpdate()//is called after update, so when the player has already moved
    {
        toPosition = followedObject.position + Vector3.up * distanceUp - followedObject.forward * distanceAway;//sets the position of the camer behind the player
        transform.position = Vector3.Lerp(transform.position, toPosition, smooth); //sets the camera behind the player. lerp=smooth following
        transform.LookAt(followedObject);
    }
}
