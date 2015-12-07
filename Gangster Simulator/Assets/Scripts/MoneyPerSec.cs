using UnityEngine;
using System.Collections;

public class MoneyPerSec : MonoBehaviour {

	public UnityEngine.UI.Text mpsDisplay;
	public Click click;
	public ItemManager[] items;

	void Start(){
		StartCoroutine (AutoTick ());
	}

	void Update(){
		mpsDisplay.text = GetMoneyPerSec () * click.multiplier2 + " Money/sec";
	}

	public float GetMoneyPerSec(){
		float tick = 0;

		foreach (ItemManager item in items) {
			tick += item.count * item.tickValue;
		}
		return tick;
	}

	public void AutoMoneyPerSec(){
		click.gold += (GetMoneyPerSec () / 10) * click.multiplier2;
	}

	IEnumerator AutoTick(){
		while (true) {
			AutoMoneyPerSec();
			yield return new WaitForSeconds(0.10f);
		}
	}
}
