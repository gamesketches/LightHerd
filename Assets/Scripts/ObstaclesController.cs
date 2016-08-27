using UnityEngine;
using System.Collections;

public class ObstaclesController : MonoBehaviour
{
	private Transform thisTransform;
	private SpriteRenderer[] obstacleRenderers;//GameObject[] obstaclesTransform;

	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;
		GameObject[] obstaclesTransform = GameObject.FindGameObjectsWithTag("obstacle");
		obstacleRenderers = new SpriteRenderer[obstaclesTransform.Length];
		for(int i = 0; i < obstaclesTransform.Length; i++){
			obstacleRenderers[i] = obstaclesTransform[i].GetComponent<SpriteRenderer>();
			Color rendererColor = obstacleRenderers[i].color;
			rendererColor.a = 0;
			obstacleRenderers[i].color = rendererColor;
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < thisTransform.childCount; i++) 
		{
			Color rendererColor = obstacleRenderers[i].color;
			if (LightController._instance.LightColorName() == obstacleRenderers[i].gameObject.name || 
				LightController._instance.LightColorName() == "Default") 
			{
				rendererColor.a = 0;
				obstacleRenderers[i].color = rendererColor;
			}
			else
			{
				rendererColor.a = 1;
				obstacleRenderers[i].color = rendererColor;
			}
		}

	
	}
}
