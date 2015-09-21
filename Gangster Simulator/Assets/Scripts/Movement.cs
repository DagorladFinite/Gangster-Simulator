using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	float timer;
	Vector3 startPos;
	Vector3 endPos;


	
	void Start() 
	{
		RandomPosition();
	}
	
	void RandomPosition()
	{
		timer = Time.time;
		startPos = transform.position;
		endPos = new Vector3(Random.Range(625.0f, 640.0f), 183.60f, 0);
	}
	
	void Update()
	{
		if (Time.time - timer > 1)
		{
			RandomPosition();
		}
		transform.position = Vector3.Lerp(startPos, endPos, Time.time - timer);
	}

}
