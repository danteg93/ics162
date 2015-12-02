using UnityEngine;
using System.Collections;

public class fireFlicker : MonoBehaviour {

    public Light fireLight;
    public float timeOn = 0.3f;
    public float timeOff = 0.3f;
    private float changeTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > changeTime){
            //fireLight.enabled = !fireLight.enabled;
            if (fireLight.intensity < 4.0f)
            {
                fireLight.intensity = 4.0f;
                changeTime = Time.time + timeOff;
            }
            else
            {
                fireLight.intensity = 3.5f;
                changeTime = Time.time + timeOn;
            }
        }
	}
}
