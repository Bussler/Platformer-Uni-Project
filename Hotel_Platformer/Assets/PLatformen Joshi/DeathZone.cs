using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public void OnDrawGizmos() {
        Gizmos.DrawIcon(gameObject.transform.position, "deathzone");
    }
}
