using UnityEngine;
using System.Collections;

public class SkyManager : MonoBehaviour {

	public GameObject Nuvol;
	public int num_nuvols;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<num_nuvols; i++) {
			float Posy = Random.Range (2.5f, 5.0f);
			float Posx = Random.Range (-10.0f, 10.0f);
			Nuvol = Instantiate (Nuvol, new Vector3 (Posx, Posy, 0), Nuvol.transform.rotation) as GameObject;
			Nuvol.transform.localScale = new Vector3 (3,3,1);
			Nuvol.transform.SetParent(transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
