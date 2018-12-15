using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarVisibilityManager : MonoBehaviour {

	
	public float delay;
	public bool brightenStars;
	private float exposure=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(brightenStars && exposure <= 3.5)
		{
			exposure += delay;
		}
		else if (!brightenStars && exposure >=0){
			exposure -= delay;
		}
		RenderSettings.skybox.SetFloat("_Exposure",exposure);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Eclipse")
		{
			brightenStars = true;
			
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Eclipse")
		{
			brightenStars = false;

			
		}
	}
}
