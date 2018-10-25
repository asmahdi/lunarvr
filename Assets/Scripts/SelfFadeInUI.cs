using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SelfFadeInUI : MonoBehaviour {

	public float fadeTime;
	public void Start()
	{
		StartCoroutine(FadeCanvasGroup(gameObject.GetComponent<CanvasGroup>(), 0,1,fadeTime));
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
}
