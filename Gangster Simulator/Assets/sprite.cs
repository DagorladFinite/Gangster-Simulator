﻿using UnityEngine;
using System.Collections;

public class sprite : MonoBehaviour {

	Vector3 end;
	float endx;
	public Vector3 start;


	// Use this for initialization
	void Start () {
		StartCoroutine(MoveObject(transform, 100.0f));
		end = new Vector3(transform.position.x - 10,transform.position.y, transform.position.z);
		endx = transform.position.x - 20;
		start = new Vector3(transform.position.x,transform.position.y, transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator MoveObject(Transform thisTransform, float time)
	{
		//bar = GameObject.FindGameObjectWithTag ("Bar") as GameObject;
		
		//Debug.Log(transform.position);
		float i = 0.0f;
		float rate = 1.0f / time;
		while (thisTransform.position != end) {
			i += Time.deltaTime * rate;

			float x = Mathf.Lerp (thisTransform.position.x, endx, i);
			thisTransform.position = new Vector3(x,thisTransform.position.y, thisTransform.position.z);
			//thisTransform.position.x = thisTransform.position.x
			yield return new WaitForSeconds (0.00002f);
			
		}
		//Destroy(gameObject);

		Destroy(gameObject);
		yield return true;
	}



}
