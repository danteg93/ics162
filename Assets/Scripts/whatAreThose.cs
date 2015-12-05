using UnityEngine;
using System.Collections;

public class whatAreThose : MonoBehaviour {

    private AudioSource sound;
    private bool inRange = false;
    private int w = 200;
    private int h = 80;
    private Rect squareThing;
    
	// Use this for initialization
	void Start () {
        sound = this.GetComponent<AudioSource>();
        squareThing = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
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
    void OnGUI()
    {
        if (inRange)
        {
            GUI.Box(squareThing, ("\nPress E to interact with\nShoes?"));
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
