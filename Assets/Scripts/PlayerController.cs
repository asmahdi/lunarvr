using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 force;
	public GameObject Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			GetComponent<Rigidbody>().AddForce(Camera.transform.forward.x,Camera.transform.forward.y,Camera.transform.forward.z, ForceMode.Impulse);
		}
		
	}
}
