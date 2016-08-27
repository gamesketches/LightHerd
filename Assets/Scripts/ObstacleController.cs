using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "Player") {
			Debug.Log(other);
			other.gameObject.transform.parent.GetComponent<CreatureMovement>().resetPosition();
		}
	}
}
