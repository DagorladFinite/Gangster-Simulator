using UnityEngine;
using System.Collections;

public class FTE : MonoBehaviour {

	public GameObject panel;
	public UnityEngine.UI.Text text;
	public Click click;
	public GameObject arrow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Part1(){
		panel.SetActive (true);
		text.text = "Tap anywhere to start collecting money from your bar";
	}

	public void Part2(){
		panel.SetActive (true);
		arrow.SetActive (true);
		text.text = "Open the Upgrades Menu in your Bar\n You can buy stuff there to improve it!";
	}

	public void Part3(){
		panel.SetActive (true);
		arrow.SetActive (true);
		arrow.GetComponent<Animation> ().Play ("arrow2");
		text.text = "You can also invest in some 'less legal'\n options to improve your income";
	}

	public void Part4(){
		panel.SetActive (true);
		//arrow.SetActive (true);
		//arrow.GetComponent<Animation> ().Play ("arrow3");
		text.text = "Watch out! Your karma levels are indicators of your behaviour \n You can always resort to the dealer";
	}


	public void close(){
		panel.SetActive (false);
		//arrow.SetActive (false);
		click.canclick = true;
	
	}
}
