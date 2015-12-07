using UnityEngine;
using System.Collections;

public class playerData : MonoBehaviour {

    private bool hasBasicKey = false;
    private bool hasSuperKey = false; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
    public void takeBasicKey()
    {
        if (!hasBasicKey)
        {
            hasBasicKey = true;
        }
    }
    public bool getBasicKey()
    {
        return hasBasicKey;
    }

    public void takeSuperKey()
    {
        if (!hasSuperKey)
        {
            hasSuperKey = true;
        }
    }
    public bool getSuperKey()
    {
        return hasSuperKey;
    }
}
