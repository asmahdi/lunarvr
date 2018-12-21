using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarVoiceAroundMoon : MonoBehaviour {

	public AudioSource copernicus;
	public AudioSource aitken;
	public AudioSource maria;
	public AudioSource temperature;

	public GameObject copernicusSpot;
	public GameObject aitkenSpot;
	public GameObject mariaSpot;

	public GameObject temperatureMap;

	void Update()
	{
		if(copernicus.isPlaying)
		{
			copernicusSpot.SetActive(true);
		}
		else 
		{
			copernicusSpot.SetActive(false);
		}
		if(aitken.isPlaying)
		{
			aitkenSpot.SetActive(true);
		}
		else 
		{
			aitkenSpot.SetActive(false);
		}
		if(maria.isPlaying)
		{
			mariaSpot.SetActive(true);
		}
		else 
		{
			mariaSpot.SetActive(false);
		}

		Debug.Log(copernicus.isPlaying);
	}


	void OnTriggerEnter(Collider col)
	{

		if(temperatureMap.GetComponent<MeshRenderer>().sharedMaterial.GetFloat("_opacity") == 0)
		{
			if(col.gameObject.tag == "copernicus")
			{
				copernicus.Play();
			}
			else if(col.gameObject.tag == "aitken")
			{
				aitken.Play();
			}
			else if(col.gameObject.tag == "maria")
			{
				maria.Play();
			}
			else if(col.gameObject.tag == "Temperature")
			{
				temperature.Play();
			}
		}

			
	}
}
