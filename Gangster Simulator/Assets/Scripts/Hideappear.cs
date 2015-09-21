using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hideappear : MonoBehaviour {

	public Click click;
	public UnityEngine.UI.Text itemInfo;
	public float cost;
	public int count = 0;
	public int clickPower;
	public string itemName;
	public Color stand;
	public Color aff;
	private float _baseCost;


	
	void Start(){

	}
	
	void Update(){
		itemInfo.text = itemName + "\nCost: " + cost + "\nPower: +" + clickPower + "\nAmount: " + count;
		
		if (click.gold >= cost) {
			GetComponent<Image> ().color = aff;
		} else {
			GetComponent<Image> ().color = stand;
		}
	}


	
	
	public void hide(){
		gameObject.SetActive (true);
	}

	public void disappear(){
		gameObject.SetActive (false);
	}
}
