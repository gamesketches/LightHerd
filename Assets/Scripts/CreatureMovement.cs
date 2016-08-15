using UnityEngine;
using System.Collections;

public class CreatureMovement: MonoBehaviour 
{
	//Line
	private Transform thisObject;
	private LineRenderer lineRender;
	private int vertexCount;
	private float moveSpeed;
	//Creature
	private Transform creaturePosition;
	private Transform targetPosition;
	private string colorName;
	//Direction
	private int priorAngle;
	private int currentAngle;


	private int timeController;

	void Start () 
	{
		thisObject = this.transform;
		lineRender = this.gameObject.GetComponent<LineRenderer>();
		vertexCount = 2;
		lineRender.SetVertexCount (vertexCount);
		moveSpeed = 2.0f;

		creaturePosition  = this.transform.FindChild("Creature");
		targetPosition = creaturePosition;
		colorName = this.gameObject.name;

		priorAngle = 0;
		currentAngle = 0;

		timeController = 0;

		thisObject.position = creaturePosition.position;
		lineRender.SetPosition (0, thisObject.position);
		lineRender.SetPosition (1, thisObject.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeController++;
		if(timeController % 5 == 0)
		{
			if (thisObject.position.x < 1600 && thisObject.position.y < 1600) 
			{
				CreatureMovementTarget ();

				currentAngle = (int)(Vector3.Angle(creaturePosition.position, targetPosition.position) * 100);
				if ((priorAngle - currentAngle > 1)) 
				{
					vertexCount++;
					lineRender.SetVertexCount (vertexCount);
				}
				priorAngle = currentAngle;
			}
			timeController = 0;

		}
		creaturePosition.position = Vector3.Lerp (creaturePosition.position, targetPosition.position , 1);
		//Debug.Log (endTarget.position);
		lineRender.SetPosition (vertexCount - 1, creaturePosition.position);

	}

	private void CreatureMovementTarget()
	{
		if (LightController._instance.LightColorName() == "White") 
		{
			targetPosition.position = new Vector3(creaturePosition.position.x + 
				Mathf.Atan2( LightController._instance.LightPosition().x - creaturePosition.position.x, 
					LightController._instance.LightPosition().y - creaturePosition.position.y) * moveSpeed * 0.1f,
				creaturePosition.position.y + 
				Mathf.Atan2( LightController._instance.LightPosition().y - creaturePosition.position.y, 
					LightController._instance.LightPosition().x - creaturePosition.position.x) * moveSpeed * 0.1f,0);
		}
		else if(LightController._instance.LightColorName() == thisObject.name)
		{
			targetPosition.position = new Vector3(creaturePosition.position.x + 
													Mathf.Atan2( LightController._instance.LightPosition().x - creaturePosition.position.x, 
													LightController._instance.LightPosition().y - creaturePosition.position.y) * moveSpeed,
												  creaturePosition.position.y + 
													Mathf.Atan2( LightController._instance.LightPosition().y - creaturePosition.position.y, 
													LightController._instance.LightPosition().x - creaturePosition.position.x) * moveSpeed,0);
		}	

	}
		
}
