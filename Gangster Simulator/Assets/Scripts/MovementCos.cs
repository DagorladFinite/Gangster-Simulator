﻿using UnityEngine;
using System.Collections;

public class MovementCos : MonoBehaviour {

    public Vector3 pointB;
    Vector3 pointA;
	GameObject bar;
    

    void Start()
    {
    pointA = transform.position;
	bar = GameObject.FindGameObjectWithTag ("Bar") as GameObject;
       
    }
    public void StartMove()
    {
        //while(transform.position != pointB)
        StartCoroutine(MoveObject(transform, pointA,bar.transform.position , 2.0f));
    }
   
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
		//bar = GameObject.FindGameObjectWithTag ("Bar") as GameObject;

        Debug.Log(transform.position);
        float i = 0.0f;
        float rate = 1.0f / time;
        while (thisTransform.position != endPos)
        {
            i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(thisTransform.position, bar.transform.position, i);
			//thisTransform.position.x = thisTransform.position.x
            yield return new WaitForSeconds(0.00002f);

        }
		transform.parent = null;
        yield return true;
		gameObject.SetActive(false);
        //yield return new WaitForSeconds(2);
		/*
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Destroy(gameObject);
        */
        // Debug.Log(transform.position);
    }

}
