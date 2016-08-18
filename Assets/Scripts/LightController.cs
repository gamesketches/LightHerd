using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour 
{
	public static LightController _instance;

	//public int choice;

	private Transform thisTransform;
	private Transform lightTransform;

	//Light Color
	private enum LIGHTCOLOR{ Default, Purple, Yellow };
	private int currentColor;
	private string colorName;
	private Color32 lightColor;
	//LightMovement
	private float moveSpeed;
	private float extraSpeed;
	private int moveRadius;
	private int moveDirection;
	private int pressController;

	private int timeController;

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;
		lightTransform = this.transform.FindChild ("Spotlight");

		currentColor = (int)LIGHTCOLOR.Default;
		colorName = LIGHTCOLOR.Default.ToString();
		lightColor = new Color32 (255, 255, 255, 255);

		moveSpeed = 0.03f;
		extraSpeed = 0.0f;
		moveDirection = 1;
		moveRadius = -3;
		pressController = 0;
	}

	void Update()
	{	
		timeController++;
		LightMovement ();
	}


	private void LightMovement()
	{
		if (Input.GetKey(KeyCode.A))
		{
			moveDirection = -1;
			extraSpeed = 0.1f;
		}
		else if(Input.GetKey(KeyCode.D))
		{
			moveDirection = 1;
			extraSpeed = 0.1f;
		}
		else
		{
			extraSpeed = 0;
		}
			
		thisTransform.RotateAround(new Vector3(0,-300,0), new Vector3(0, 0, moveRadius), (moveSpeed + extraSpeed) * moveDirection);
	}


	public void ChooseColor (int _choice) 
	{
		currentColor = _choice;
		switch (currentColor) 
		{
		case 0:
			lightColor = new Color32 (255, 255, 255, 255);
			colorName = LIGHTCOLOR.Default.ToString ();
	//		Debug.Log (colorName);
			break;
		case 1:
			lightColor = new Color32 (124, 73, 129, 255);
			colorName =  LIGHTCOLOR.Purple.ToString();
			break;
		case 2:
			lightColor = new Color32 (211, 218, 154, 255);
			colorName = LIGHTCOLOR.Yellow.ToString();
			break;
		default:
			lightColor = new Color32 (255, 255, 255, 255);
			colorName = LIGHTCOLOR.Default.ToString();
			break;
		}
		thisTransform.gameObject.GetComponent<SpriteRenderer> ().color = lightColor;
		lightTransform.gameObject.GetComponent<Light> ().color = lightColor;
	}

	public string LightColorName()
	{
		Debug.Log (colorName);
		return colorName;
	}

	public Vector3 LightPosition()
	{
		return thisTransform.position;
	}
}
