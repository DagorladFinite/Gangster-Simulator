using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	public AudioSource[] musicSource;
	public Sprite sprite;
	public Sprite original;
	public UnityEngine.UI.Button button;
	bool pressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pressed(){
	if (pressed == false) {
			button.image.sprite = sprite;
			for (int i = 0; i<musicSource.Length; i++)
			{
			musicSource[i].volume = 0;
			}
			pressed = true;
		} else if (pressed == true) {
			button.image.sprite = original;
			for (int i = 0; i<musicSource.Length; i++)
			{
				musicSource[i].volume = 0.2f;
			}

			pressed = false;
		
		}
	}

}
