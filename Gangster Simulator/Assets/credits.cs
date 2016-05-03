using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
	public UnityEngine.UI.Text text;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		text.text = "The Anvil Pig\n\nDeveloped by:\n\nDaniel Castello\n\n and \n\nRobert Coll";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hide()
	{
		panel.SetActive(false);
	}
}
