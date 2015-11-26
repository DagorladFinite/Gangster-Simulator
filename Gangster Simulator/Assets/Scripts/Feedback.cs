using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Feedback : MonoBehaviour {
	//public GameObject click;
	public Text text;
	public string input = " ";
	int duracio = 50;
	// Use this for initialization
	void Start () {
		//Click click = transform.Find ("Click").GetComponent<Click> () as Click;
		text.text = input;//click.goldperclick.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (duracio <= 0)
			Destroy (gameObject);
		else
			duracio--;
	}
}
