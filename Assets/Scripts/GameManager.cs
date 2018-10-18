using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public AudioSource bgMusic;

	private int menuShowCount;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		
	}
	
	// Update is called once per frame
	void Update () {

		if(SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "SceneManager")
		{
			if(!bgMusic.isPlaying)
			{
				bgMusic.Play();
			}
		}
		else
		{
			bgMusic.Stop();
		}



		Application.targetFrameRate = 60;

		
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		if(Input.GetMouseButtonUp(0))
		{
			menuShowCount++;
		}

		if(menuShowCount ==2 )
		{
			SceneManager.LoadSceneAsync("Menu");
			menuShowCount = 0;
		}

		if(menuShowCount == 1)
		{
			Invoke("Reset",1);
		}


		
	}


	public void Reset()
	{
		menuShowCount = 0;
	}
}
