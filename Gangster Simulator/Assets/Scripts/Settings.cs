using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	public UnityEngine.CanvasGroup pp;
	public Click click;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Return (){
		GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
		for (int i= 0; i<pjs.Length; i++) {
			SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
				foreach (SpriteRenderer rnd in rend)
				rnd.enabled = true;

			
		}
		click.set = false;
		pp.alpha = 0;
		pp.blocksRaycasts = false;
		pp.interactable = false;
		click.canclick = true;
	
	}
}
