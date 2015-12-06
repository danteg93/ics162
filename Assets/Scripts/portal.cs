using UnityEngine;
using System.Collections;

public class portal : MonoBehaviour {

	public GameObject otherPortal;
	static bool teleporting = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		Debug.Log("TELEPORT DAMN IT");
		if(!teleporting){
			teleporting = true;
			obj.gameObject.transform.position = otherPortal.transform.position;
		}
	}
	void OnTriggerExit(Collider obj){
		Debug.Log("TELEPORT DAMN IT");
		if(teleporting){
			teleporting = false;
		}
	}
}
