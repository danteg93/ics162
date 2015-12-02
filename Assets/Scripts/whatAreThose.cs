using UnityEngine;
using System.Collections;

public class whatAreThose : MonoBehaviour {

    private AudioSource sound;
    private bool inRange = false;
	// Use this for initialization
	void Start () {
        sound = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inRange)
        {
            if (Input.GetKeyDown("e"))
            {
                sound.Play();
            }     
        }
	}

    void OnTriggerEnter(Collider obj)
    {
        inRange = true;
    }
    void OnTriggerExit(Collider obj)
    {
        inRange = false;
    }
}
