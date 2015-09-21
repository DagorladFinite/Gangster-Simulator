using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text GoldDisplay;
	public UnityEngine.UI.Text mpc;
	public float gold = 0.00f;
	public int goldperclick = 1;
	public double karma = 0;
	//private float h = Screen.height / 2;
	//private float w = Screen.width / 2;
	//cancer

	public bool popup1 = false; 
	public bool popup2 = false; 
	public bool canclick = true;
	public Texture aTexture;
	public Texture aTexture2;
	private float time = 0;

	//GUI.Button(new Rect(10, 20, 100, 20), "Hello World");

	void Update(){
		GoldDisplay.text = "Money: " + gold.ToString("F0") + " filthy coins";
		mpc.text = goldperclick + " Money/click";
		checkifpopup1 ();
		checkifpopup2 ();
	}

	public void Clicked(){
		if (canclick == true) {
			gold += goldperclick;
		}

	}
	void OnGUI() {
		if (popup1) {

			
			Rect windowRect = new Rect (Screen.width / 3, Screen.height / 3, 500, 650);
			windowRect.center = new Vector2 (Screen.width / 2, Screen.height / 2);
			windowRect = GUI.Window (0, windowRect, DoMyWindow, "POPUP1");
			GUI.DrawTexture (windowRect, aTexture, ScaleMode.ScaleToFit, false, 0.0f);
			canclick = false;
			Time.timeScale = 0;

		
		}
		if (popup2) {


			Rect windowRect = new Rect(Screen.width / 3, Screen.height / 3, 500, 650);
			windowRect.center = new Vector2(Screen.width / 2, Screen.height / 2);
			windowRect = GUI.Window (0, windowRect, DoMyWindow, "POPUP2");
			GUI.DrawTexture(windowRect, aTexture2, ScaleMode.ScaleToFit, false, 0.0f);
			canclick = false;
			Time.timeScale = 0;


		}
	}
	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (130, 475, 250, 150), "Click Me!")) {
			popup1 = false;
			popup2 = false;
			canclick = true;
			Time.timeScale = 1;
		}
	}

	void checkifpopup1()
	{ 
		int random = Random.Range (0, 10000);
		if (karma >= 50 && random <= 50 && Time.time - time > Random.Range (60, 600)) {
			popup1 = true;
			time = Time.time;
		} 

	}

	void checkifpopup2()
	{
		int random = Random.Range (0, 10000);
		if (karma <= -50 && random <= 50 && Time.time - time > Random.Range (60, 600)) {
			popup2 = true;
			time = Time.time;
		}
	}
}
