using UnityEngine.UI;
using UnityEngine;

public class MenuApearance : MonoBehaviour {


	public GameObject MainCamera;
	public bool inverse;
	private float alpha;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(MainCamera != null)
		{
			if(MainCamera.transform.eulerAngles.x > 0 && MainCamera.transform.eulerAngles.x < 60 && !inverse)
			{
				alpha = MainCamera.transform.eulerAngles.x * 1/60;
				if (GetComponent<Image>() != null)
				{
					GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,GetComponent<Image>().color.b, alpha );
				}
				if(GetComponent<Text>() != null)
				{
					GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g,GetComponent<Text>().color.b, alpha );
				}
				
			}
			
			else if(MainCamera.transform.eulerAngles.x < 359 && MainCamera.transform.eulerAngles.x > 300 && inverse )
			{
				alpha = (360 - MainCamera.transform.eulerAngles.x) * 1/60;
				if (GetComponent<Image>() != null)
				{
					GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,GetComponent<Image>().color.b, alpha );
				}
				if(GetComponent<Text>() != null)
				{
					GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g,GetComponent<Text>().color.b, alpha );
				}
			}

			// Debug.Log(alpha);
		}
		
	}
}
