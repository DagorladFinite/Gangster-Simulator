using UnityEngine;
using System.Collections;

public class Karma : MonoBehaviour {
	
	public UnityEngine.UI.Text karma;
	public Click click;
	public ItemManager[] items;
	public UpgradeManager[] upgrades;

	
	void Start(){
		StartCoroutine (AutoTick ());
	}
	
	void Update(){
		karma.text = string.Format("{0:0.##}",click.karma) + " Karma" ;
	}
	
	public double GetKarmaPerSec(){
		float tick = 0.0f;
		float itemcount = 0.0f;
		float upgradecount = 0.0f;
		float karma = 0.0f;
		
		foreach (ItemManager item in items) {
			itemcount += item.count;
		}
		foreach (UpgradeManager upgrade in upgrades) {
			upgradecount += upgrade.count;
		}

		karma = upgradecount - itemcount;

		if (upgradecount > itemcount)
		{
			float p = 0.1f * karma;
			tick += Mathf.Abs(p);
		}

		else if(upgradecount < itemcount)
		{
			float p = 0.1f * karma;
			tick -= Mathf.Abs(p);
		}

		return tick ;
	}
	
	public void AutoKarmaPerSec(){
		click.karma += GetKarmaPerSec ();
	}
	
	IEnumerator AutoTick(){
		while (true) {
			AutoKarmaPerSec();
			yield return new WaitForSeconds(0.10f);
		}
	}
}