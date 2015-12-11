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
	float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void positive(){
		if (click.gold >= positiveCost) {
			click.gold = click.gold - positiveCost;
			click.karma = click.karma + karmaGainPositive;
			time = 10.0f;
			StartCoroutine(Deal (1, time, multiplier,positiveCost));
			broker.Return();
	
		}
	}

	public void negative(){
		if (click.gold >= negativeCost) {
			click.gold = click.gold - negativeCost;
			click.karma = click.karma - karmaGainNegative;
			time = 10.0f;
			StartCoroutine(Deal (2, time, multiplier,negativeCost));
			broker.Return();
			
		}
	}

	IEnumerator Deal(int type, float time, float multiplier, float cost){
	
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < time) {
			i += Time.deltaTime * rate;
			yield return new WaitForSeconds(0.00002f);
			//Debug.Log (i);
		}
		//Debug.Log ("Hola");
		click.gold = click.gold + (cost * multiplier);
		yield return true;
	}
}
