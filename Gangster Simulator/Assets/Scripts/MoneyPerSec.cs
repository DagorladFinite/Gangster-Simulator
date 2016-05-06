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
		mpsDisplay.text = click.FormatNumber((GetMoneyPerSec () * click.multiplier2 + click.extra)) + " Money/sec";
	}

	public float GetMoneyPerSec(){
		float tick = 0;

		foreach (ItemManager item in items) {
			tick += item.count * item.tickValue;
		}
		return tick;
	}

	public void AutoMoneyPerSec(){
		click.gold += ((GetMoneyPerSec () / 10) * click.multiplier2) + click.extra;
	}

	IEnumerator AutoTick(){
		while (true) {
			AutoMoneyPerSec();
			yield return new WaitForSeconds(0.10f);
		}
	}
}
