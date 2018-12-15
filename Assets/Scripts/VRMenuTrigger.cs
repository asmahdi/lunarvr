using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VRMenuTrigger : MonoBehaviour {

	public GameObject LoadingShape;
	public float loadingSpeed;

	public enum Type{ Scene, Animate, GameObject}


	public Type usageType;
	public string SceneToActive;
	public GameObject ObjectToActive;
	public Animator AnimatorToActive;
	public string AnimatorFloat;
	public float FloatValue;
	public bool Active;
	
    


    private bool gazedAt;
	private bool loaded;


    void Start () {
		
	}
	

	void LateUpdate () 
	{
		if (gazedAt)
			{
				if (LoadingShape.GetComponent<Image>().fillAmount != 1f)
				{
					
					LoadingShape.GetComponent<Image>().fillAmount = LoadingShape.GetComponent<Image>().fillAmount + Time.deltaTime * loadingSpeed;
				}
			}
		else
			{
				if (LoadingShape.GetComponent<Image>().fillAmount != 0f)
				{
					
					LoadingShape.GetComponent<Image>().fillAmount = LoadingShape.GetComponent<Image>().fillAmount - Time.deltaTime * loadingSpeed*10;
				}
			}

			if (LoadingShape.GetComponent<Image>().fillAmount == 1)
				{
					loaded = true;
					gazedAt = false;
				}
			else 
				{
					loaded = false;
					
				}

		if(loaded)
		{
			
			Debug.Log("loaded menu!");


			switch (usageType)
			{
				case Type.Scene : 
				if(SceneToActive != null)
				Initiate.Fade(SceneToActive,Color.black,1); 
				break;

				case Type.GameObject :
				ObjectToActive.SetActive(Active);
				break;

				case Type.Animate :
				AnimatorToActive.SetFloat(AnimatorFloat,FloatValue);
				break;

				
			}

			


		}		
	}

	void OnEnable()
	{
		LoadingShape.GetComponent<Image>().fillAmount = 0;
	}

	public void SetGazedAt(bool isGazed)
	{
		this.gazedAt = isGazed;
	}
}
