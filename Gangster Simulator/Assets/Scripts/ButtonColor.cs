using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour {
	public Deals deals;
	public Color stand;
	public Color aff;
	float time = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		if (deals.cd == true) {
			GetComponent<Image> ().color = aff;
			GetComponentInChildren<Text> ().enabled = false;


		} else {
			GetComponent<Image> ().color = stand;
			GetComponentInChildren<Text> ().enabled = true;
			time = time - (1/deals.time);
			GetComponentInChildren<Text> ().text = time.ToString();
		}
	}
}
