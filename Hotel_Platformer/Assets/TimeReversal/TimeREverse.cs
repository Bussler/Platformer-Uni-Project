using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeREverse : MonoBehaviour {

    // private Stack<TRObject> objectsOnStack = new Stack<TRObject>();
    private CircularBuffer objectsInCircularBuffer = new CircularBuffer(1000);
    private ITR otherScript;
    void Start()
    {
        otherScript = (ITR)gameObject.GetComponent(typeof(ITR));
    }
    void FixedUpdate()
    {
        if (Input.GetButton("TimeControl"))
        {
            if (objectsInCircularBuffer.Count > 0)
                otherScript.LoadTRObject(objectsInCircularBuffer.Pop());
        }
        else
            otherScript.SaveTRObject();

    }

    public void PushTRObject(TRObject trobject)
    {
        objectsInCircularBuffer.Push(trobject);
    }

}
