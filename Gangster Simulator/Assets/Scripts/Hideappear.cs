using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hideappear : MonoBehaviour {

	bool active = false;


	
	void Start(){

	}
	
	void Update(){

	}


	
	
	public void hide(){
		print ("Hola");
		if (active == false) {
			gameObject.SetActive (true);
		} else if(active == true){
			gameObject.SetActive (false);
		}
	}

	public void disappear(){

	}
}
