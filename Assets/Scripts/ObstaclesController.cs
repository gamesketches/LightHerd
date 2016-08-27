using UnityEngine;
using System.Collections;

public class ObstaclesController : MonoBehaviour
{
	private Transform thisTransform;
	private Animator[] obstacleAnimators;

	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;
		GameObject[] obstaclesTransform = GameObject.FindGameObjectsWithTag("obstacle");
		obstacleAnimators = new Animator[obstaclesTransform.Length];
		for(int i = 0; i < obstaclesTransform.Length; i++){
			obstacleAnimators[i] = obstaclesTransform[i].GetComponent<Animator>();
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < thisTransform.childCount; i++) 
		{
			if (LightController._instance.LightColorName() == obstacleAnimators[i].gameObject.name || 
				LightController._instance.LightColorName() == "Default") 
			{
				obstacleAnimators[i].SetBool("active", false);
			}
			else
			{
				obstacleAnimators[i].SetBool("active", true);
			}
		}

	
	}
}
