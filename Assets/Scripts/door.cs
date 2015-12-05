using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
    //GUI Stuff
    private int w = 200;
    private int h = 80;
    private Rect squareThing;

    //Class stuff
    private bool inRange = false;
    private bool animating = false;
    private bool open = false;
    private float currentY = 0;
    public GameObject publicDoor;
	// Use this for initialization
	void Start () {
        squareThing = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
    }
	// Update is called once per frame
	void Update () {
        if (inRange)
        {
            if (Input.GetKeyDown("e"))
            {
                //publicDoor.transform.Rotate(0.0f, 90.0f, 0.0f);
                Debug.Log(publicDoor.transform.rotation.eulerAngles);
                animating = true;
            }
        }
        if (animating && !open) //opening door
        {
            currentY += 1.0f;
            //Debug.Log(currentY);
            publicDoor.transform.Rotate(0.0f, 1.0f, 0.0f);
            if (currentY >= 90)
            {
                animating = false;
                open = true;
            }
        }
        else if (animating)
        {
            currentY = currentY - 1.0f;
            //Debug.Log(currentY);
            publicDoor.transform.Rotate(0.0f, -1.0f, 0.0f);
            if (currentY < 1.0f)
            {
                animating = false;
                open = false;
            }
        }
	}
    void OnGUI()
    {
        if (inRange && !open && !animating)
        {
            GUI.Box(squareThing, ("\nPress E to open door"));
        }
        else if(inRange && !animating)
        {
            GUI.Box(squareThing, ("\nPress E to close door"));
        }
    }
    void OnTriggerEnter(Collider obj)
    {
        //Debug.Log("WTF");
        inRange = true;
    }
    void OnTriggerExit(Collider obj)
    {
        inRange = false;
    }
}
