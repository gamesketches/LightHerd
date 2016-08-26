using UnityEngine;
using System.Collections;

public class ObstaclesController : MonoBehaviour
{
	private Transform thisTransform;
	private GameObject[] obstaclesTransform;

	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;
		obstaclesTransform = GameObject.FindGameObjectsWithTag("obstacle");

		foreach(GameObject obj in obstaclesTransform){
			obj.SetActive (false);
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < thisTransform.childCount; i++) 
		{
			if (LightController._instance.LightColorName() == obstaclesTransform [i].name || 
				LightController._instance.LightColorName() == "Default") 
			{
				obstaclesTransform [i].SetActive (false);
			}
			else
			{
				obstaclesTransform [i].SetActive (true);
			}
		}

	
	}
}
