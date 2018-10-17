using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]

public class VRPointTrigger : MonoBehaviour {


	public GameObject Player;
	public string[] openRoute;
	public string[] closeRoute;

	public Image LoadingShape;
	public float loadingSpeed;
	public GameObject TargetFixedEffect;
	public GameObject NextActiveTarget;
	public GameObject NextActiveSubTarget;
	public GameObject NextDeactiveTarget;
	public GameObject NextDeactiveSubTarget;


	private bool gazedAt;
	private bool loaded;

	// Use this for initialization
	void Start () {

		gazedAt = false;
		SetGazedAt(gazedAt);
		
	}

	void OnEnable()
	{
		LoadingShape.fillAmount = 0;
	}
	
	// Update is called once per frame
	 public void SetGazedAt(bool isGazed) {
		this.gazedAt = isGazed;
	  
	  
    }

	void Update(){

		if (gazedAt)
	  {
		 

		  if (LoadingShape.fillAmount != 1f)
        {
            LoadingShape.fillAmount = LoadingShape.fillAmount + Time.deltaTime * loadingSpeed;
        }
	  }
	  else{
		   if (LoadingShape.fillAmount != 0f)
			{
				LoadingShape.fillAmount = LoadingShape.fillAmount - Time.deltaTime * loadingSpeed*10;
			}	
	  }

		if (LoadingShape.fillAmount == 1)
		{
			loaded = true;
			gazedAt = false;
		}
		else 
		{
			loaded = false;
		}

		if (loaded)
		{
			for (int i =0 ; i < openRoute.Length ; i++)
			{
				Player.GetComponent<Animator>().SetFloat(openRoute[i],1);
			}
			for (int i =0 ; i < closeRoute.Length ; i++)
			{
				Player.GetComponent<Animator>().SetFloat(closeRoute[i],-1);
			}
			// Instantiate(TargetFixedEffect,gameObject.transform.position,gameObject.transform.rotation);
			if (NextActiveTarget != null)
			{
				NextActiveTarget.SetActive(true);
			}
			if (NextActiveSubTarget != null)
			{
				NextActiveSubTarget.SetActive(true);
			}

			if (NextDeactiveTarget != null)
			{
				NextDeactiveTarget.SetActive(false);
			}
			if (NextDeactiveSubTarget != null)
			{
				NextDeactiveSubTarget.SetActive(false);
			}
			
			// Destroy(this.gameObject);


		}

		
		

	}


}

