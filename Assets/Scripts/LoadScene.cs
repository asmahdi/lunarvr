
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public string sceneName;
	public float damp = 1;
	public GameObject SceneLoaderUI;

	// Use this for initialization
	void Start () {
		// Initiate.Fade(sceneName,Color.black,damp );
		StartCoroutine(LoadAsyncronously());
	}
	
	IEnumerator LoadAsyncronously()
	{
		Initiate.Fade(sceneName,Color.black,damp );
		if(SceneLoaderUI != null)
		{
			SceneLoaderUI.SetActive(true);
		}

		yield return null;
	} 

}
