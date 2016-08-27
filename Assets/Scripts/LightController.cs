using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightController : MonoBehaviour 
{
	public static LightController _instance;

	private Transform thisTransform;
	private Transform lightTransform;

	//Light Color
	private enum LIGHTCOLOR{ Default, Purple, Yellow };
	private int currentColor;
	private string colorName;
	private Color32 lightColor;
	private Toggle purpleToggle;
	private Toggle yellowToggle;
	private GoalScript[] goals;
	//LightMovement
	private float moveSpeed;
	private float extraSpeed;
	private int moveRadius;
	private int moveDirection;

	//Background
	private Transform bgTransform;
	private Color32 bgColor;

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
		moveRadius = -3;
		moveDirection = 1;

		bgTransform = this.transform.root.FindChild ("Background");
		bgColor = new Color32(255, 255, 255, 255);
		bgTransform.gameObject.GetComponent<SpriteRenderer> ().color = bgColor;

		purpleToggle = this.transform.root.FindChild("Canvas").GetChild(0).GetComponent<Toggle>();
		yellowToggle = this.transform.root.FindChild("Canvas").GetChild(1).GetComponent<Toggle>();
		GameObject[] temp = GameObject.FindGameObjectsWithTag("goal");
		goals = new GoalScript[temp.Length];
		goals[0] = temp[0].GetComponent<GoalScript>();
		goals[1] = temp[1].GetComponent<GoalScript>();

		timeController = 0;
	}

	void Update()
	{	
		CheckToggles();
		timeController++;
		LightMovement ();
		CheckWin();
	}

	private void CheckToggles()
	{

		if(purpleToggle.isOn && (!yellowToggle.isOn))
		{
			ChooseColor(1);
		}
		else if(yellowToggle.isOn && (!purpleToggle.isOn))
		{
			ChooseColor(2);
		}
		else 
		{
			ChooseColor(0);
		}
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
			bgColor = new Color32 (255, 255, 255, 255);
	//		Debug.Log (colorName);
			break;
		case 1:
			lightColor = new Color32 (124, 73, 129, 255);
			colorName = LIGHTCOLOR.Purple.ToString ();
			bgColor = new Color32 (235, 155, 155, 255);
			break;
		case 2:
			lightColor = new Color32 (211, 218, 154, 255);
			colorName = LIGHTCOLOR.Yellow.ToString();
			bgColor = new Color32 (239, 140, 136, 255);
			break;
		default:
			lightColor = new Color32 (255, 255, 255, 255);
			colorName = LIGHTCOLOR.Default.ToString();
			bgColor = new Color32 (255, 255, 255, 255);
			break;
		}
		thisTransform.gameObject.GetComponent<SpriteRenderer> ().color = lightColor;
		lightTransform.gameObject.GetComponent<Light> ().color = lightColor;
		bgTransform.gameObject.GetComponent<SpriteRenderer> ().color = bgColor;
	}

	public string LightColorName()
	{
		return colorName;
	}

	public Vector3 LightPosition()
	{
		return thisTransform.position;
	}

	void CheckWin() 
	{
		foreach(GoalScript goal in goals)
		{
			if(!goal.winner) 
			{
				return;
			}
		}

		Debug.Log("You win!");
		Debug.Break();
	}
}
