using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Profilchanger : MonoBehaviour {

    public PostProcessingProfile profile;
     public ColorGradingModel.Settings settings;
    // Use this for initialization
    void Start () {

          
}
	
	// Update is called once per frame
	void Update () {
        settings = profile.colorGrading.settings;

        settings.basic.hueShift++;
        profile.colorGrading.settings= settings;

    }
}
