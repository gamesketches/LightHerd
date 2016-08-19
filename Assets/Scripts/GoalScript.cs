using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour
{

//	public Color targetColor;
	public bool winner;
	// Use this for initialization
	void Start () 
	{
		winner = false;
//		GetComponent<SpriteRenderer>().color = targetColor;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player") 
		{
		//	SpriteRenderer renderer = other.gameObject.GetComponent<SpriteRenderer>();
		//	if(renderer.color == targetColor)
			if(other.transform.parent.name == this.transform.name)
			{
				winner = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		winner = false;
	}
}
