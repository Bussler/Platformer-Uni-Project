using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour {
    public float mMax;
    public float mMin;
    public bool moveX;
    public bool moveY;
    public bool moveZ;
    public float moveSpeed;
    private bool moveback = false;
    
    //Variablen zum Berechnen der Bewegung
    private float moveXMax;
    private float moveXMin;
    private float moveYMax;
    private float moveYMin;
    private float moveZMax;
    private float moveZMin;

    // Use this for initialization
    void Start()
    {//Belegen der Werte, zwischen denen bewegt werden soll

        if (moveX == true)
        {
             moveXMax = transform.position.x + mMax;
             moveXMin = transform.position.x - mMin;
        }
        if (moveY == true)
        {
            moveYMax = transform.position.y + mMax;
            moveYMin = transform.position.y - mMin;
        }
        if (moveZ == true)
        {
            moveZMax = transform.position.z + mMax;
            moveZMin = transform.position.z - mMin;
        }
    }
	
	// Update is called once per frame
	void Update () { //bewegen der Plattform
        float amtToMove = moveSpeed * Time.deltaTime;//The amount to move each frame
        if (moveX==true)//bewegen entlang der x-achse
        {
            if (moveback==false)
            {
                transform.Translate(Vector3.right*amtToMove);//Moves Objekt
                if (transform.position.x>= moveXMax)//maximale distanz erreicht
                {
                    moveback = true;
                }
            }
            if (moveback == true)
            {
                transform.Translate(Vector3.left * amtToMove);//Moves Objekt
                if (transform.position.x <= moveXMin)//minimale
                {
                    moveback = false;
                }
            }
        }
        if (moveY==true)//bewegen entlang der y-achse
        {
            if (moveback == false)
            {
                transform.Translate(Vector3.up * amtToMove);//Moves Objekt
                if (transform.position.y >= moveYMax)//maximale distanz erreicht
                {
                    moveback = true;
                }
            }
            if (moveback == true)
            {
                transform.Translate(Vector3.down * amtToMove);//Moves Objekt
                if (transform.position.y <= moveYMin)//minimale
                {
                    moveback = false;
                }
            }
        }
        if (moveZ==true)//bewegen entlang der z achse
        {
            if (moveback == false)
            {
                transform.Translate(Vector3.forward * amtToMove);//Moves Objekt
                if (transform.position.z >= moveZMax)//maximale distanz erreicht
                {
                    moveback = true;
                }
            }
            if (moveback == true)
            {
                transform.Translate(Vector3.back * amtToMove);//Moves Objekt
                if (transform.position.z <= moveZMin)//minimale
                {
                    moveback = false;
                }
            }
        }
		//transform.Translate
	}

}
