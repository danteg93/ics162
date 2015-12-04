using UnityEngine;
using System.Collections;

public class fireFlicker : MonoBehaviour {

    public Light fireLight;
    public float timeOn = 0.3f;
    public float timeOff = 0.3f;
    private float changeTime = 0;
    public float intesityAddition = 0.3f;
    private float lightFactor;
        // Use this for initialization
	void Start () {
        lightFactor = fireLight.intensity + intesityAddition;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > changeTime){
            //fireLight.enabled = !fireLight.enabled;
            if (fireLight.intensity < lightFactor)
            {
                fireLight.intensity = lightFactor;
                changeTime = Time.time + timeOff;
            }
            else
            {
                fireLight.intensity = fireLight.intensity - intesityAddition;
                changeTime = Time.time + timeOn;
            }
        }
	}
}
