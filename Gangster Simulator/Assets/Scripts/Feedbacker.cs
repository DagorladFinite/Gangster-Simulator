﻿using UnityEngine;
using System.Collections;

public class Feedbacker : MonoBehaviour {
	GameObject fed;
	public GameObject feedback;
	public Click click;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		Vector2 mousePos = Input.mousePosition;
		//mousePos.z = 2.0;       // we want 2m away from the camera position
		Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		//fed = Instantiate(feedback, new Vector2 (Input.mousePosition.x-300,Input.mousePosition.y-450), Quaternion.identity)as GameObject;
		fed = Instantiate(feedback, new Vector2 (mousePos.x-275,mousePos.y-450), Quaternion.identity)as GameObject;
		fed.transform.SetParent(transform, false);
		fed.GetComponent<Feedback> ().input = click.goldperclick.ToString();
		Debug.Log (Input.mousePosition);
	
	}
}
