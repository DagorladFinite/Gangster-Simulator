using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LayerManager: MonoBehaviour {
	
	public Click click;
	public UnityEngine.UI.Text itemInfo;
	public float cost;
	public bool purchased;
	public string itemName;
	public Color stand;
	public Color aff;
	public int id;
	public float scale = 0.0001f;
	public int childs = 0;



	
	
	void Awake()
	{
		int count = 0;
		foreach (Transform child in transform) {
			count++;
		}
		childs = count - 1;
		Debug.Log (childs);
	}
	
	
	void Start(){

	}
	
	void Update(){
		itemInfo.text = itemName + "\nCost: " + cost;
		
		if (click.gold >= cost) {
			GetComponent<Image> ().color = aff;
		} else {
			GetComponent<Image> ().color = stand;
		}
	}
	
	public void PurchasedUpgrade(){
		if (click.gold >= cost && click.canclick == true) {
			click.gold -= cost;
			purchased = true;
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(true);
			}
			this.transform.localScale = new Vector3(0.001F,0.001F,0.001F);
		}
	}
	public void PurchasedLoad(){
		purchased = true;
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(true);
		}
		this.transform.localScale = new Vector3(0.001F,0.001F,0.001F);
	}

}
