using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForLuna : MonoBehaviour {

	public AudioSource LunaVoice;
	public GameObject ToActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(!LunaVoice.isPlaying)
		{
			ToActive.SetActive(true);
		}
		else
		{
			ToActive.SetActive(false);
		}
		
	}
}
