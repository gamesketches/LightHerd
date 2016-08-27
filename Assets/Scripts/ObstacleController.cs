using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour 
{
	private Transform thisTransform;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float movementProgress;
	private float timeController;


	// Use this for initialization
	void Start () 
	{
		thisTransform = this.transform;
		startPosition = thisTransform.position;
		endPosition = new Vector3 (Random.Range(-500 , 500), thisTransform.position.y, thisTransform.position.z);
		movementProgress = 0.1f;
		timeController = 0;

	}

	void Update()
	{
		timeController += Time.deltaTime;
		Debug.Log (timeController);
		if(timeController > 3)
		{
			startPosition = thisTransform.position;
			endPosition = new Vector3 (Random.Range(-500 , 500), thisTransform.position.y, thisTransform.position.z);
			StartCoroutine ("Move");
			timeController = 0;
		}

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "Player") {
			Debug.Log(other);
			other.gameObject.transform.parent.GetComponent<CreatureMovement>().resetPosition();
		}
	}

	IEnumerator Move()
	{
		while (movementProgress < 0.3f ||(0.5f < movementProgress && movementProgress < 0.7f ))
		{
			thisTransform.position = Vector3.Lerp (startPosition, endPosition, movementProgress);
			movementProgress += Time.deltaTime;
			yield return null;
		}

		while ((0.3f < movementProgress && movementProgress< 0.5f)||(0.7f < movementProgress && movementProgress < 1)) 
		{
			thisTransform.position = Vector3.Lerp (startPosition, endPosition, movementProgress);
			movementProgress += Time.deltaTime * 1.2f;
			yield return null;
		}
		movementProgress = 0.1f;
		yield break;
	}
}
