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
    public bool locked = false;
    public bool superKey = false;

    private float speedFactor = 100.0f;
    private playerData data;
	// Use this for initialization
	void Start () {
        squareThing = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
        data = (GameObject.FindGameObjectWithTag("playerData")).GetComponent<playerData>();
    }
	// Update is called once per frame
	void Update () {
        if (locked && inRange)
        {
            if (superKey && data.getSuperKey())
            {
                if (Input.GetKeyDown("e"))
                {
                    locked = false;
                    animating = true;
                }   
            }
            else if(!superKey && data.getBasicKey())
            {
                if (Input.GetKeyDown("e"))
                {
                    locked = false;
                    animating = true;
                }   
            }
        }
        else if (inRange)
        {
            if (Input.GetKeyDown("e"))
            {
                animating = true;
            }
        }
        animateDoor();
	}
    private void animateDoor(){
        if (animating && !open) //opening door
        {
            currentY += (Time.deltaTime * speedFactor);
            publicDoor.transform.Rotate(0.0f, (Time.deltaTime * speedFactor), 0.0f);
            if (currentY >= 90)
            {
                animating = false;
                open = true;
            }
        }
        else if (animating)
        {
            currentY += (-Time.deltaTime * speedFactor);
            publicDoor.transform.Rotate(0.0f, (-Time.deltaTime * speedFactor), 0.0f);
            if (currentY < 1.0f)
            {
                animating = false;
                open = false;
            }
        }
    }
    void OnGUI()
    {
        if (inRange && !animating)
        {
            if (locked && superKey && data.getSuperKey())
            {
                GUI.Box(squareThing, ("\nPress E to unlock super door"));
            }
            else if (locked && superKey && !data.getSuperKey())
            {
                GUI.Box(squareThing, ("\nYou need a Super Key to\nunlock this door"));
            }
            else if (locked && !superKey && data.getBasicKey())
            {
                GUI.Box(squareThing, ("\nPress E to unlock regular door"));
            }
            else if (locked && !superKey && !data.getBasicKey())
            {
                GUI.Box(squareThing, ("\nYou need a Regular Key to\nunlock this door"));
            }
            else if (!open)
            {
                GUI.Box(squareThing, ("\nPress E to open door"));
            }
            else
            {
                GUI.Box(squareThing, ("\nPress E to close door"));
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
