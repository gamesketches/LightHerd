using UnityEngine;
using System.Collections;using UnityEngine;
using System.Collections;

public class ThirdPersonMovement: MonoBehaviour 
{
	//Line
	private Transform thisObject;
	private LineRenderer lineRender;
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
	private float xSpeed;
	private float ySpeed;


	private int timeController;

	void Start () 
	{
		thisObject = this.transform;
		lineRender = this.gameObject.GetComponent<LineRenderer>();
		vertexCount = 2;
		lineRender.SetVertexCount (vertexCount);
		moveSpeed = 0.5f;
		defaultStartWidth = (int)Random.Range (5, 15);
		defaultEndWidth = defaultStartWidth - 3;
		currentEndWidth = defaultEndWidth;
		maxEndWidth = defaultEndWidth * 10;

		creatureTransform  = this.transform.FindChild("Creature");
		targetTransform = creatureTransform;
		colorName = this.gameObject.name;

		priorAngle = 0;
		currentAngle = 0;

		timeController = 0;
		xSpeed = 0;
		ySpeed = 0;

		thisObject.position = creatureTransform.position;
		lineRender.SetWidth (defaultStartWidth, defaultEndWidth);
		lineRender.SetPosition (0, thisObject.position);
		lineRender.SetPosition (1, thisObject.position);
	}

	// Update is called once per frame
	void Update () 
	{
		
		CreatureMovementTarget (0, 0);
		creatureTransform.rotation =  Quaternion.Euler(0, 0, timeController);
		if (Input.GetKey(KeyCode.A)) 
		{ 
			timeController+= 2;
			xSpeed = -1;
		}
		else if(Input.GetKey(KeyCode.D))
		{
			timeController-= 2;
			xSpeed = 1;
		}

		if (Input.GetKey (KeyCode.W))
		{
			ySpeed = 1;
		}
		else if (Input.GetKey (KeyCode.S)) 
		{
			ySpeed = -1;
		}
		creatureTransform.rotation =  Quaternion.Euler(0, 0, timeController);
		CreatureMovementTarget (xSpeed, ySpeed);
		currentAngle = (int)(Vector3.Angle(creatureTransform.position, targetTransform.position) * 100);

		if ((priorAngle - currentAngle > 1)) 
		{
			vertexCount++;
			lineRender.SetVertexCount (vertexCount);
		}
		priorAngle = currentAngle;

		creatureTransform.position = Vector3.Lerp (creatureTransform.position, targetTransform.position, 1);
		lineRender.SetWidth (defaultStartWidth, currentEndWidth);
		//Debug.Log (endTarget.position);
		lineRender.SetPosition (vertexCount - 1, creatureTransform.position);
		colorName = thisObject.name;

	}

	private void CreatureMovementTarget(float _x, float _y)
	{

		targetTransform.position = new Vector3 (creatureTransform.position.x + _x * moveSpeed, creatureTransform.position.y + _y * moveSpeed, 0); 
	}

}

