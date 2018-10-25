using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class LoadVR : MonoBehaviour {

	 void Start()
    {
		Invoke("LoadVRScene", 5);
        
    }

 

	public void LoadVRScene()
	{
		StartCoroutine(LoadDevice("Cardboard"));
		Initiate.Fade("VRSceneManager",Color.black,1 );

	}

	   IEnumerator LoadDevice(string newDevice)
    {
        if (string.Compare(XRSettings.loadedDeviceName, newDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;
        }
	}
}
