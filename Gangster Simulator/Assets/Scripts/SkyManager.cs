using UnityEngine;
using System.Collections;

public class SkyManager : MonoBehaviour {

	public GameObject Nuvol;
	public int num_nuvols;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<num_nuvols; i++) {
			float Posy = Random.Range (5.0f, 50.0f);
			float Posx = Random.Range (-5.0f, 5.0f);
			Nuvol = Instantiate (Nuvol, new Vector3 (Posx, Posy, 0), Nuvol.transform.rotation) as GameObject;
			Nuvol.transform.localScale = new Vector3 (1,1,1);
			Nuvol.transform.SetParent(transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
