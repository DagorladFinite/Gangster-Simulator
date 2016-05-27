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
            float rate = 1.0f / 10.0f;
            time = time - Time.deltaTime * rate; 
			//float minutes = Mathf.Floor(time / 60).ToString("00");
			//float seconds = Mathf.Floor(time % 60).ToString("00");

			GetComponentInChildren<Text> ().text = Mathf.Floor (time*10).ToString();
		}
	}
}
