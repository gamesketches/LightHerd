using UnityEngine;
using System.Collections;

public class CreatureMovement: MonoBehaviour 
{
	//Line
	private Transform thisObject;
	private LineRenderer lineRender;
	private Vector3 startingPosition;
	private int vertexCount;
	private float moveSpeed;
	private int defaultStartWidth;
	private float defaultEndWidth;
	private float currentEndWidth;
	private float maxEndWidth;
	//Creature
	private Transform creatureTransform;
	private Transform targetTransform;
	private string colorName;
	//Direction
	private int priorAngle;
	private int currentAngle;
	//Goback
	private float goBackProgress;

	private int timeController;

	void Start () 
	{
		thisObject = this.transform;
		startingPosition = thisObject.position;
		lineRender = this.gameObject.GetComponent<LineRenderer>();
		vertexCount = 2;
		lineRender.SetVertexCount (vertexCount);
		moveSpeed = 1.0f;
		defaultStartWidth = (int)Random.Range (5, 15);
		defaultEndWidth = defaultStartWidth - 3;
		currentEndWidth = defaultEndWidth;
		maxEndWidth = defaultEndWidth * 6;

		creatureTransform  = this.transform.FindChild("Creature");
		targetTransform = creatureTransform;
		colorName = this.gameObject.name;

		priorAngle = 0;
		currentAngle = 0;

		goBackProgress = 0.1f;
		timeController = 0;

		thisObject.position = creatureTransform.position;
		lineRender.SetWidth (defaultStartWidth, defaultEndWidth);
		lineRender.SetPosition (0, thisObject.position);
		lineRender.SetPosition (1, thisObject.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeController++;

		if(timeController % 3 == 0)
		{
			if (thisObject.position.x < 1600 && thisObject.position.y < 1600) 
			{
				CreatureMovementTarget ();

				currentAngle = (int)(Vector3.Angle(creatureTransform.position, targetTransform.position) * 100);
			
				if ((priorAngle - currentAngle > 1)) 
				{
					vertexCount++;
					lineRender.SetVertexCount (vertexCount);
				}
				priorAngle = currentAngle;
			}
			timeController = 0;

		}
		creatureTransform.position = Vector3.Lerp (creatureTransform.position, targetTransform.position, .1f);
		lineRender.SetWidth (defaultStartWidth, currentEndWidth);
		//Debug.Log (endTarget.position);
		lineRender.SetPosition (vertexCount - 1, creatureTransform.position);
		colorName = thisObject.name;

	}

	public void resetPosition()
	{
		StartCoroutine ("GoBack");
	}

	IEnumerator GoBack()
	{
		while (goBackProgress < 1)
		{
			creatureTransform.position = Vector3.Lerp (creatureTransform.position, startingPosition, goBackProgress);
			goBackProgress *= 1.01f;
			yield return null;
		}
		lineRender.SetWidth (defaultStartWidth,defaultStartWidth);
		goBackProgress = 0.1f;
		yield break;
	}

	private void CreatureMovementTarget()
	{
		if(LightController._instance.LightColorName() == "Default")
		{
			moveSpeed = 0.0f;
			targetTransform.position = new Vector3(creatureTransform.position.x + 
													Mathf.Cos(Mathf.Atan2(LightController._instance.LightPosition().y - creatureTransform.position.y, 
																LightController._instance.LightPosition().x - creatureTransform.position.x)) * moveSpeed,
												  creatureTransform.position.y + 
													Mathf.Sin(Mathf.Atan2( LightController._instance.LightPosition().y - creatureTransform.position.y, 
																LightController._instance.LightPosition().x - creatureTransform.position.x) )* moveSpeed,0);
		}
		else if(LightController._instance.LightColorName() == colorName)
		{
			if (currentEndWidth < maxEndWidth) 
			{
				currentEndWidth += 0.1f;
			}
			moveSpeed = 1.0f;
			targetTransform.position = new Vector3(creatureTransform.position.x + 
													Mathf.Cos(Mathf.Atan2(LightController._instance.LightPosition().y - creatureTransform.position.y, 
																LightController._instance.LightPosition().x - creatureTransform.position.x)) * moveSpeed,
												  creatureTransform.position.y + 
													Mathf.Sin(Mathf.Atan2( LightController._instance.LightPosition().y - creatureTransform.position.y, 
																LightController._instance.LightPosition().x - creatureTransform.position.x) )* moveSpeed,0);
				
			
		}
		else
		{
			if (currentEndWidth > defaultEndWidth) 
			{
				
				currentEndWidth -= 0.1f;
			}
			moveSpeed = -0.5f;
			targetTransform.position = new Vector3(creatureTransform.position.x + 
													Mathf.Cos(Mathf.Atan2(LightController._instance.LightPosition().y - creatureTransform.position.y, 
																LightController._instance.LightPosition().x - creatureTransform.position.x)) * moveSpeed,
												   creatureTransform.position.y +
													Mathf.Sin(Mathf.Atan2( LightController._instance.LightPosition().y - creatureTransform.position.y, 
																LightController._instance.LightPosition().x - creatureTransform.position.x) )* moveSpeed * 0.05f, 0);
			
		}

	}
		
}
