using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISequenceHandler : MonoBehaviour {

	public float transitionTime;
	public float visibleTime;

	public CanvasGroup[] canvasGroupObjects;

	public GameObject ActiveAtEnd;

	private int cg_counter = 0;

	public void Start()
	{
		ActiveAtEnd.SetActive(false);
		InvokeRepeating("FadeSequence",1,transitionTime + visibleTime );
		
	}

	public void Update()
	{
		if(cg_counter >= canvasGroupObjects.Length)
		{
			CancelInvoke();
			ActiveAtEnd.SetActive(true);

		}
	}

	public IEnumerator FadeCanvasGroup(CanvasGroup cg,float start, float end, float lerpTime)
	{
		float _timeStartedLerp = Time.time;
		float timeSinceLerp = Time.time - _timeStartedLerp;
		float lerpPercentage = timeSinceLerp / lerpTime;

		while(true)
		{
			timeSinceLerp = Time.time - _timeStartedLerp;
			lerpPercentage = timeSinceLerp / lerpTime;
			
			float currentLerpValue = Mathf.Lerp(start,end,lerpPercentage);
			cg.alpha = currentLerpValue;

			if(lerpPercentage >= 1) {break;}
			
			yield return new WaitForEndOfFrame();
		}
		
	} 


	public void FadeSequence()
	{	
		FadeIn_UI();
		Invoke("FadeOut_UI",visibleTime);

	}


	public void FadeIn_UI()
	{
		StartCoroutine(FadeCanvasGroup(canvasGroupObjects[cg_counter],canvasGroupObjects[cg_counter].alpha,1,transitionTime));
		
	}
	public void FadeOut_UI()
	{
		StartCoroutine(FadeCanvasGroup(canvasGroupObjects[cg_counter],canvasGroupObjects[cg_counter].alpha,0,transitionTime));
		cg_counter++;
	}
}
