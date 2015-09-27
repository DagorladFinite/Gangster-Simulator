using UnityEngine;
using System.Collections;

public class MovementCos : MonoBehaviour {
	
	float timer;
	Vector3 startPos;
	Vector3 endPos;
	//Movement otherScript;
	
	void Start() 
	{
		//otherScript = GetComponent<Movement> ();
		RandomPosition();
	}
	
	void RandomPosition()
	{
		timer = Time.time;
		startPos = transform.position;
		endPos = new Vector3(Random.Range(625.0f, 640.0f), 183.12f, 0);
		//endPos = otherScript.endPos;
	}
	
	void Update()
	{
		//otherScript = GetComponent<Movement> ();
		if (Time.time - timer > 1)
		{
			RandomPosition();
		}
		transform.position = Vector3.Lerp(startPos, endPos, Time.time - timer);


	}
	
}
