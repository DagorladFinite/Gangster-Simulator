using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class GetChilds : MonoBehaviour {
	public List<GameObject> childs;
	// Use this for initialization
	void Start () {
		childs = new List<GameObject>();

		foreach (Transform child in transform)
		{
			if(child.gameObject.tag == "Upgrade"){
				childs.Add(child.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
