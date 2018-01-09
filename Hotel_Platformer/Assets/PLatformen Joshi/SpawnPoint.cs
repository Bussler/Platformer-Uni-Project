using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public int index;
    public void OnDrawGizmos() { Gizmos.DrawIcon(gameObject.transform.position, "spawnpoint"); }
   
}
