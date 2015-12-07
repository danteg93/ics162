using UnityEngine;
using System.Collections;

public class movePlatform : MonoBehaviour {

    private float platformSpeed = 6.0f;
    private float currentX = 0;
    private bool inverse = false;
    public GameObject platform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!inverse)
        {
            currentX += (Time.deltaTime * platformSpeed);
            platform.transform.Translate((Time.deltaTime * platformSpeed), 0, 0);
            if (currentX > 10)
            {
                inverse = true;
            }
        }
        else{
            currentX += (-Time.deltaTime * platformSpeed);
            platform.transform.Translate((-Time.deltaTime * platformSpeed), 0, 0);
            if (currentX < 0)
            {
                inverse = false;
            }
        }  
	}
}
