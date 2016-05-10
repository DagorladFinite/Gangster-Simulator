using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public Click click;
	public UnityEngine.UI.Text itemInfo;
	public float cost;
	public int count = 0;
	public int clickPower;
	public string itemName;
	public Color stand;
	public Color aff;
	public int id;
	private float _baseCost;
	private float _basePower;
	//public int buyings = 0;

	
	void Awake()
	{

	}


	void Start(){
		_baseCost = cost;
		_basePower = clickPower;
	}

	void Update(){
		itemInfo.text = itemName + "\nCost: " + click.FormatNumber(cost) + "\nPower: +" + clickPower + "\nAmount: " + count;

		if (click.gold >= cost) {
			GetComponent<Image> ().color = aff;
		} else {
			GetComponent<Image> ().color = stand;
		}
	}

	public void PurchasedUpgrade(){
		if (click.gold >= cost && click.canclick == true) {
			click.gold -= cost;
			count += 1;
			click.goldperclick += clickPower;
			cost =Mathf.Round( _baseCost* Mathf.Pow (1.15f, count));
			click.buyings++;

			if (click.buyings == 10 && click.pis_current< click.pisos.Length)
			{
				click.pisos[click.pis_current].SetActive(true);
				click.pis_current++;
				click.buyings = 0;
			}
		}
	}

}
