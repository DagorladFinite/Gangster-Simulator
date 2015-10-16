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
		pp.alpha = 0;
		pp.blocksRaycasts = false;
		pp.interactable = false;
		click.canclick = true;
	
	}
}
