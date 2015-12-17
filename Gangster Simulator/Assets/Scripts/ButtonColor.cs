using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour {
	public Deals deals;
	public Color stand;
	public Color aff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		if (deals.cd == true) {
			GetComponent<Image> ().color = aff;
		} else {
			GetComponent<Image> ().color = stand;
		}
	}
}
