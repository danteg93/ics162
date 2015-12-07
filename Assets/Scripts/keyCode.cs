using UnityEngine;
using System.Collections;

public class keyCode : MonoBehaviour {
    private bool inRange = false;
    private int w = 200;
    private int h = 80;
    private Rect squareThing;
    public bool superKey = false;
    private playerData data;
    public GameObject parent;
	// Use this for initialization
	void Start () {
        squareThing = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
        data = (GameObject.FindGameObjectWithTag("playerData")).GetComponent<playerData>();
    }
	
	// Update is called once per frame
	void Update () {
        if (inRange && !superKey)
        {
            if (Input.GetKeyDown("e"))
            {
                data.takeBasicKey();
                Destroy(parent);
                  
            }  
        }
        else if (inRange && superKey)
        {
            if (Input.GetKeyDown("e"))
            {
                data.takeSuperKey();
                Destroy(parent);
            }  
        }
	
	}
    void OnGUI()
    {
        if (inRange && !superKey)
        {
            GUI.Box(squareThing, ("\nPress E to pick up\nBasic Key"));
        }
        else if (inRange && superKey)
        {
            GUI.Box(squareThing, ("\nPress E to pick up\nSuper Key"));
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
