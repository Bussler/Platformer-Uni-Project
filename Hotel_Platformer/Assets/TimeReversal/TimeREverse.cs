using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeREverse : MonoBehaviour {

    // private Stack<TRObject> objectsOnStack = new Stack<TRObject>();
    private CircularBuffer objectsInCircularBuffer = new CircularBuffer(1000);
    private ITR otherScript;
    public PlayerMovmentTest player;
    void Start()
    {
        otherScript = (ITR)gameObject.GetComponent(typeof(ITR));
    }
    void FixedUpdate()
    {
        if (player.hasAbilityTimeReversal) {
            if (Input.GetButton("TimeReversal"))
            {
                Debug.Log("Time");
              player.canBeControlled = false;
                if (objectsInCircularBuffer.Count > 0)
                {
                    Debug.Log("Time2");
                    otherScript.LoadTRObject(objectsInCircularBuffer.Pop());
                }
            }
            else
            {
               
                otherScript.SaveTRObject();
                player.canBeControlled = true;
            }
        }
    }

    public void PushTRObject(TRObject trobject)
    {
        objectsInCircularBuffer.Push(trobject);
    }

}
