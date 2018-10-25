using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieforLuna : MonoBehaviour {

	public AudioSource LunaVoice;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!LunaVoice.isPlaying)
		{
			Invoke("killSelf",1);
		}
	}


	void killSelf()
	{
        Destroy(gameObject);
	}
}
