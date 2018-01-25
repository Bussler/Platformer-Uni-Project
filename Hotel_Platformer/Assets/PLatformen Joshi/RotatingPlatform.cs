using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour, ITR
{
   // public float rotatingSpeed;
    public Vector3 rotatingDirection;
    public bool rotateAroundPoint;
    public Transform point;
    //private TimeREverse trscript;
   

    public void LoadTRObject(TRObject trobject)
    {
        MyStatus newStatus = (MyStatus)trobject;
        transform.rotation = newStatus.myRotation;
    }

    public void SaveTRObject()
    {
        MyStatus status = new MyStatus();
        status.myRotation = transform.rotation;
        //trscript.PushTRObject(status);
    }

    // Use this for initialization
    void Start()
    {
        //trscript = GetComponent<TimeREverse>();
        if (rotateAroundPoint)
        {
            this.transform.parent = point;
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (GameData.Instance.Paused &&
            gameObject.GetComponent<TimeREverse>() != null)
            return;*/


      
        Rotate();
    }

    private class MyStatus : TRObject
    {
        public Quaternion myRotation;
    }


    public void Rotate()
    {
        if (rotateAroundPoint)
        {
            point.Rotate(rotatingDirection );
        }
        else
        {
            this.transform.Rotate(rotatingDirection*Time.deltaTime);
        }

    }

}
