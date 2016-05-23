using UnityEngine;
using System.Collections;

public class Popups2 : MonoBehaviour {
	
	public UnityEngine.CanvasGroup pp;
	public Click click;

	public UnityEngine.UI.Text text;
	double sub= 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateText(){
		sub =((click.gold * 10) / 100);
		text.text = "Bad boy! The Police requires " + click.FormatNumber (sub) + " of your money";
		
	}

	public void Return (){
		GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
		for (int i= 0; i<pjs.Length; i++) {
			SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer rnd in rend)
				rnd.enabled = true;
			
			
		}
		click.gold = click.gold - ((click.gold * 10) / 100);
		pp.alpha = 0;
		pp.blocksRaycasts = false;
		pp.interactable = false;
		click.canclick = true;
		Time.timeScale = 1;
		click.SR.enabled = true;
		//click.SR2.enabled = true;
		
	}
}
