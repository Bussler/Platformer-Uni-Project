using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class TakeDrugsAnim : MonoBehaviour {
    public GameObject PLane;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;

    public Animator anim;
    public Light light;

    public Light spotlight1;
    public Light spotlight2;
    public Light spotlight3;
    public FirstPersonController first;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Takedrug()
    {
        first.enabled = true;
        Destroy(PLane);
        part1.active = true;
            part2.active = true;
        //part3.active = true;
        anim.enabled = false;
        light.intensity = 0;
        light.type = LightType.Point;
        spotlight1.intensity = 5;
        spotlight2.intensity = 5;
        spotlight3.intensity = 5;
        
    }
}
