using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject Pj;
	public float Posx;
	public int max_quantity;

	// Use this for initialization
	void Start () {

		/*GameObject g;
		GameObject d;
		g = Instantiate (Cara,new Vector3(Posx,183.60f,-0.69f),transform.rotation) as GameObject;
		g.GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
		d = Instantiate (Cos,new Vector3(Posx,183.12f,-0.69f),transform.rotation) as GameObject;
		d.GetComponent<SpriteRenderer>().sprite = cossos[Random.Range (0,8)];
		*/
		Posx = 626.0f;
		for (int i = 0; i<max_quantity; i++) {
			Pj = Instantiate (Pj,new Vector3(Posx,183.65f,0.0f),transform.rotation) as GameObject;
			//Pj.transform.SetParent(transform);
			Posx = Posx+0.2f;
		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
