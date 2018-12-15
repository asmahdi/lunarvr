using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForLuna : MonoBehaviour {

	public AudioSource LunaVoice;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!LunaVoice.isPlaying)
		{
			Invoke("StopSelf",1);
		}
	}


	void StopSelf()
	{
        gameObject.SetActive(false);
	}
}

