using UnityEngine;
using System.Collections;

public class youWon : MonoBehaviour {
    private int w = 200;
    private int h = 80;
    private Rect squareThing;
    private bool youHaveWon = false;
    private bool inRange;
	// Use this for initialization
    private int w2 = 800;
    private int h2 = 800;
    private Rect winThing;
    private MeshRenderer meshy; 
	void Start () {
        squareThing = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
        winThing = new Rect((Screen.width - w2) / 2, (Screen.height - h2) / 2, w2, h2);
        meshy = gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inRange)
        {
            if (Input.GetKeyDown("e"))
            {
                youHaveWon = true;
                meshy.enabled = false;
            }  
        }
	}
    void OnGUI()
    {
        if (inRange && !youHaveWon)
        {
            GUI.Box(squareThing, ("\nPress E to WIN"));
        }
        else if (youHaveWon)
        {
            GUI.Box(winThing, ("\n\n\nYOU\n\nWON!!!!!\n\nPress ESC to exit game"));
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
