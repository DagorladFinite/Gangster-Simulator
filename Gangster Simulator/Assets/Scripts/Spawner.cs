using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public Sprite[] cossos;
	public Sprite[] cares;
	public GameObject Cara;
	public GameObject Cos;
	public float Posx;
	
	
	// Use this for initialization
	void Start () {
		GameObject cares1;
		GameObject cossos1;

		/*GameObject g;
		GameObject d;
		g = Instantiate (Cara,new Vector3(Posx,183.60f,-0.69f),transform.rotation) as GameObject;
		g.GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
		d = Instantiate (Cos,new Vector3(Posx,183.12f,-0.69f),transform.rotation) as GameObject;
		d.GetComponent<SpriteRenderer>().sprite = cossos[Random.Range (0,8)];
		*/
	
			Posx = Random.Range (625.0f, 640.0f);
			cares1 = Instantiate (Cara,new Vector3(Posx,transform.position.y,transform.position.z),transform.rotation) as GameObject;
			cares1.GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
			cares1.transform.parent = transform;
			cossos1 = Instantiate (Cos,new Vector3(Posx,transform.position.y - 0.40f,transform.position.z),transform.rotation) as GameObject;
			cossos1.GetComponent<SpriteRenderer>().sprite = cossos[Random.Range (0,8)];
			cossos1.transform.parent = transform;
			

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
