using UnityEngine;
using System.Collections;

public class Deals : MonoBehaviour {
	public Click click;
	public float positiveCost;
	public float negativeCost;
	public float karmaGainPositive;
	public float karmaGainNegative;
	public float multiplier;
	public Broker broker;
	public float cooldown;
	public float timer;
	public bool cd;
	public float time;
	public UnityEngine.UI.Text posText;
	public UnityEngine.UI.Text negText;
	public FTE fte;

	// Use this for initialization
	void Start () {
		timer = Time.time;
		cd = true;
	}
	
	// Update is called once per frame
	void Update () {
		posText.text = "Investment: " + positiveCost + "\nKarma Repercussion: " + "+" + karmaGainPositive + "\nInvestment Multiplier: " + multiplier;
		negText.text = "Investment: " + negativeCost + "\nKarma Repercussion: " + "-" + karmaGainNegative + "\nInvestment Multiplier: " + multiplier;
	
	}

	public void positive(){
		if (click.gold >= positiveCost && cd == true ) {
			time = 10.0f;
			cd = false;
			timer = Time.time + time;
			click.gold = click.gold - positiveCost;
			click.karma = click.karma + karmaGainPositive;
			StartCoroutine(Deal (1, time, multiplier,positiveCost));
            karmaGainPositive = karmaGainPositive * 0.9f;
            positiveCost = positiveCost * 1.1f;
            multiplier = Random.Range(1, 3);
            broker.Return();
			//cd= false;
	
		}
	}

	public void negative(){
		if (click.gold >= negativeCost && cd == true ) {
			time = 10.0f;
			cd = false;
			timer = Time.time + time;
			click.gold = click.gold - negativeCost;
			click.karma = click.karma - karmaGainNegative;
			StartCoroutine(Deal (2, time, multiplier,negativeCost));
            karmaGainNegative = karmaGainNegative * 0.9f;
            negativeCost = negativeCost * 1.1f;
            multiplier = Random.Range(1, 3);
            broker.Return();

			
		}
	}

	IEnumerator Deal(int type, float time, float multiplier, float cost){
		Debug.Log ("Hola");
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < time) {
			i += Time.deltaTime * rate;
			yield return new WaitForSeconds(0.00002f);
			//Debug.Log (i);
		}
		click.gold = click.gold + (cost * multiplier);
		cd = true;
		//timer = Time.time;
		yield return true;

		fte.Dealer(cost * multiplier);
		
	}
}
