using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MenuPlayerOffset : MonoBehaviour {

	public Vector3 Offset;
	public GameObject Player;
	public GameObject mainCamera;
	public float MovementSmoothness;
	public GameObject MainMenu;
	public bool followYAxis;
	private bool isFollowing;



	private Quaternion desiredRot;

	// Use this for initialization
	void Start () {
		this.isFollowing = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(followYAxis)
		{
			transform.position = new Vector3(Player.transform.position.x+Offset.x, Player.transform.position.y+Offset.y, Player.transform.position.z+Offset.z);
		}
		else 
		{
			transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
		}



		if(isFollowing)
		{
			FollowCameraRotation();
		}
		

		desiredRot = Quaternion.Euler(transform.eulerAngles.x,mainCamera.transform.eulerAngles.y,transform.eulerAngles.z);
		
	}

	public void DonotFollow()
	{
		this.isFollowing = false;
	}
	public void Follow()
	{
		this.isFollowing = true;
	}

	private void FollowCameraRotation()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation,desiredRot,MovementSmoothness);
	}

}
