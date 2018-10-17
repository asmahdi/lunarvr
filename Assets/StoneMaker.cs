using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMaker : MonoBehaviour {

	public GameObject[] rock;
	public float height;
	public float maxRock ;
	public float min_Size, max_Size;
	public float max_X;
	public float max_Z;
	public Vector3[] targets;

	public GameObject[] rockObjects;

	// Use this for initialization
	void Start () {
		


		for (int i = 0 ; i< maxRock; i++)
		{
			targets[i] = new Vector3(Random.Range(-max_X,max_X),height,Random.Range(-max_Z,max_Z));
			rockObjects[i] = Instantiate(rock[Random.Range(0,rock.Length)],targets[i],transform.rotation);
			rockObjects[i].transform.localScale = new Vector3(Random.Range(min_Size,max_Size),Random.Range(min_Size,max_Size),Random.Range(min_Size,max_Size));

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
