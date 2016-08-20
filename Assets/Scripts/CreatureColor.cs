using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatureColor : MonoBehaviour
{
	private Transform thisTransform;
	//Sprite
	private SpriteRenderer creatureSprite;
	private Color32 spriteColor;
	//Line
	private LineRenderer creatureLine;
	private Color32 currentStartColor;
	private Color32 currentEndColor;
	//Toggle
	private Transform[] toggleTransform = new Transform[2];
	//CrearueColor
	private string colorName;


	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;

		creatureSprite = thisTransform.FindChild ("Creature").GetComponent<SpriteRenderer>();
		spriteColor = new Color32 (255, 255, 255, 255);
		creatureSprite.color = spriteColor;

		creatureLine = thisTransform.GetComponent<LineRenderer> ();
		currentStartColor= new Color32 (244, 255, 173, 255);
		currentEndColor = new Color32 (255, 255, 255, 255);
		creatureLine.SetColors (currentStartColor, currentEndColor);

		for (int i = 0; i < thisTransform.root.FindChild ("Canvas").childCount; i++)
		{
			toggleTransform[i] = thisTransform.root.FindChild ("Canvas").GetChild (i);
		}

		colorName = "Default";
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < thisTransform.root.FindChild ("Canvas").childCount; i++)
		{
			toggleTransform[i] = thisTransform.root.FindChild ("Canvas").GetChild (i);
			if (toggleTransform [i].GetComponent<Toggle>().isOn) 
			{
				colorName = toggleTransform [i].name;
			}
		}
		SetColor (colorName);
	}


	public void SetColor (string _colorname)
	{
		if (_colorname == "Default") 
		{
			spriteColor = new Color32 (255, 255, 255, 255);
			currentStartColor = currentEndColor;
			currentEndColor = new Color32 (255, 255, 255, 255);
		}
		else if (_colorname == "Purple")
		{
			spriteColor = new Color32 (205, 111, 255, 255);
			currentStartColor = currentEndColor;
			currentEndColor = new Color32 (216, 149, 236, 255);
		} 
		else if (_colorname == "Yellow") 
		{
			spriteColor = new Color32 (255, 248, 189, 255);
			currentStartColor = currentEndColor;
			currentEndColor = new Color32 (236, 140, 139, 255);
		}
		thisTransform.name = _colorname;
		creatureSprite.color = spriteColor;
		creatureLine.SetColors (currentStartColor, currentEndColor);
	}
}
