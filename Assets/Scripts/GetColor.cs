using UnityEngine;
using System.Collections;

public class GetColor : MonoBehaviour 
{
	private Transform[] colorToggle = new Transform[10];

	void Start()
	{
		for (int i = 0; i < this.transform.root.FindChild("Canvas").childCount; i++) 
		{
			colorToggle[i] =  this.transform.root.FindChild("Canvas").GetChild(i);
			colorToggle [i].gameObject.SetActive (false);
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "goal") 
		{
			for (int i = 0; i < colorToggle.Length; i++) 
			{
				if(colorToggle[i].name == other.name)
				{
					colorToggle[i].gameObject .SetActive(true);
					break;
				}
			}

		}
	}
}
