using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {

    public float gravity = -9.81f;

    public void Attract(Transform player)
    {
        Vector3 localUp = (player.position - transform.position).normalized;
        Vector3 playerUp = player.up;
        player.rotation = Quaternion.FromToRotation(playerUp, localUp) * player.rotation;
        player.GetComponent<Rigidbody>().AddForce(localUp * gravity);
    }
}
