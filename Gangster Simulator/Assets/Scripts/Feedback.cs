using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Feedback : MonoBehaviour {
	//public GameObject click;
	public Text text;
	public string input = " ";
	int duracio = 75;
	// Use this for initialization
	void Start () {
		//Click click = transform.Find ("Click").GetComponent<Click> () as Click;
		text.text = input;//click.goldperclick.ToString();
		Vector2 rand = new Vector2 (Random.Range (-75, 75), Random.Range (100, 300));
		this.GetComponent<Rigidbody2D>().AddForce (rand);
		//transform.rotation = transform.rotation * Quaternion.Euler(Random.Range(-10,10),0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (duracio <= 0)
			Destroy (gameObject);
		else
			duracio--;
	}
}
