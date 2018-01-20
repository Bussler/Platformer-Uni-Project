using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloating : MonoBehaviour {

    Vector3 startPosition;
    int richtung = 1;
    public float Speed;
    private void Start() {
        startPosition = this.transform.position;
    }
    // Update is called once per frame
    void Update () {
         if(transform.position.y < startPosition.y - 0.5f) {
            richtung *= -1;
           }
         if(transform.position.y > startPosition.y + 0.5f) {
            richtung *= -1;
        }
        transform.Translate(new Vector3(0, richtung, 0) * Time.deltaTime * Speed,Space.World);
        
	}
}
