using UnityEngine;
using System.Collections;

public class ObstaclesController : MonoBehaviour
{
	private Transform thisTransform;
	private Transform[] obstaclesTransform = new Transform[100];

	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;
		for (int i = 0; i < thisTransform.childCount; i++) 
		{
			obstaclesTransform [i] = thisTransform.GetChild (i);
			obstaclesTransform [i].gameObject.SetActive (false);
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
				obstaclesTransform [i].gameObject.SetActive (false);
			}
			else
			{
				obstaclesTransform [i].gameObject.SetActive (true);
			}
		}

	
	}
}
