using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public UnityEngine.UI.Text itemInfo;
	public UnityEngine.UI.Text cst;
	public UnityEngine.UI.Text mps;
	public UnityEngine.UI.Text amnt;
	public UnityEngine.UI.Text name;
	public Image img;
	public Click click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	public Color stand;
	public int id;
	public Color aff;
	private float _baseCost;
	public Sprite original;
	public Sprite T2;

	void Awake()
	{

	}
	void Start(){
		_baseCost = cost;
		if (count >= 10) {
			
			img.sprite = T2;
		}
	}

	void Update(){
		itemInfo.text = itemName + "\nCost: " + click.FormatNumber(cost) + "\nMoney: " + tickValue + "/s" + "\nAmount: " + count;
		cst.text = cost.ToString();
		mps.text = tickValue.ToString();
		amnt.text = count.ToString();
		name.text = itemName;
		if (click.gold >= cost) {
			GetComponent<Image> ().color = aff;
		} else {
			GetComponent<Image> ().color = stand;
		}
	}

	public void PurchasedItem(){
		if (click.fte3Arrow == false && click.canclick == true) {
			click.fte3Arrow = true;
			click.arrow.SetActive(false);
		}
		if (click.gold >= cost && click.canclick == true) {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round ( _baseCost * Mathf.Pow (1.15f, count));

		}
		if (count == 10) {
			
			img.sprite = T2;
		}
		click.Save ();
	}

    public void reset()
    {
        img.sprite = original;
    }



	

}
