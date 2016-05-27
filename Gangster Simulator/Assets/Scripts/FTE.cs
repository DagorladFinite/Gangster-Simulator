using UnityEngine;
using System.Collections;

public class FTE : MonoBehaviour {

	public GameObject panel;
	public UnityEngine.UI.Text text;
	public Click click;
	public GameObject arrow;
	public GameObject sett;

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
		text.text = "You can also invest in some\n 'less legal'\n options to improve your income";
	}

	public void Part4(){
		panel.SetActive (true);
		//arrow.SetActive (true);
		//arrow.GetComponent<Animation> ().Play ("arrow3");
		text.text = "Watch out! Your karma levels are indicators of your behaviour \n You can always resort to the dealer";
	}

	public void Part5(){
		panel.SetActive (true);
		//arrow.SetActive (true);
		//arrow.GetComponent<Animation> ().Play ("arrow3");
		sett.GetComponent<Animation> ().Play ("settings");
		text.fontSize = 15;
		text.text = "Whenever you are ready, you can leave this bar behind and move to a new city \n you will get a passive income for every time you do this \n Select prestige in the options menu to start again!";
	}
	public void Offline(double gold){
		panel.SetActive (true);
		//arrow.SetActive (true);
		//arrow.GetComponent<Animation> ().Play ("arrow3");
		text.text = "You got: " + click.FormatNumber(gold) +" from your offline earnings!";
	}

	public void Dealer(double inv){
		panel.SetActive (true);
		//arrow.SetActive (true);
		//arrow.GetComponent<Animation> ().Play ("arrow3");
		text.text = "You got: " + click.FormatNumber(inv) +" from your dealer investment!";
	}



	public void close(){
		panel.SetActive (false);
		//arrow.SetActive (false);
		click.canclick = true;
	
	}
}
