using UnityEngine;
using System.Collections;

public class leverTowers : MonoBehaviour {
    //GUI Stuff
    private int w = 200;
    private int h = 80;
    private Rect squareThing;
    //Class
    private bool inRange = false;
    private bool animating = false;
    private bool animatingTowers = false;
    private bool towersDown = true;
    private bool open = false;
    private float currentY = 0;
    private float currentYTowers = -5.0f;
    private float speedConstant = 0.01f;

    private GameObject[] towers;
    public GameObject publicLever;
	// Use this for initialization
	void Start () {
        squareThing = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
        towers = GameObject.FindGameObjectsWithTag("Tower");
    }
	
	// Update is called once per frame
	void Update () {
        if (inRange && !animatingTowers)
        {
            if (Input.GetKeyDown("e"))
            {
                //publicDoor.transform.Rotate(0.0f, 90.0f, 0.0f);
                Debug.Log(publicLever.transform.rotation.eulerAngles);
                animating = true;
            }
        }
        if (animating && !open) //opening door
        {
            currentY += 1.0f;
            //Debug.Log(currentY);
            publicLever.transform.Rotate(1.0f, 0.0f, 0.0f);
            if (currentY >= 60)
            {
                animatingTowers = true;
                animating = false;
                open = true;
            }
        }
        else if (animating)
        {
            currentY = currentY - 1.0f;
            //Debug.Log(currentY);
            publicLever.transform.Rotate(-1.0f, 0.0f, 0.0f);
            if (currentY < 1.0f)
            {
                animatingTowers = true;
                animating = false;
                open = false;
            }
        }

        if (animatingTowers && towersDown)
        {
            Debug.Log("Towers going up");
            currentYTowers += speedConstant;
            Debug.Log(currentYTowers);
            foreach (GameObject tower in towers)
            {
                tower.transform.Translate(0.0f, speedConstant, 0.0f);
            }
            if (currentYTowers > 0)
            {
                animatingTowers = false;
                towersDown = false;
            }
        }
        else if (animatingTowers)
        {
            Debug.Log("Towers going down");
            currentYTowers += (-speedConstant);
            Debug.Log(currentYTowers);
            foreach (GameObject tower in towers)
            {
                tower.transform.Translate(0.0f, -speedConstant, 0.0f);
            }
            if (currentYTowers < -5)
            {
                animatingTowers = false;
                towersDown = true;
            }
        }

    }
    void OnGUI()
    {
        if (inRange && !animating && !animatingTowers && towersDown)
        {
            GUI.Box(squareThing, ("\nPress E to raise towers"));
        }
        else if (inRange && !animating && !animatingTowers && !towersDown)
        {
            GUI.Box(squareThing, ("\nPress E to lower towers"));
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
