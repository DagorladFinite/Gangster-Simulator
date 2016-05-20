using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {
	public GameObject[] cars;
	GameObject Cardu;
	float timer3 = 0;
	public Transform panel;
    public Transform orig;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - timer3 >= Random.Range (10,15)) {
			timer3 = Time.time;
			Spawn();
			//Debug.Log("Hola");
			
		}
	
	}

	public void Spawn(){
		
		Random.seed = (int)Time.time;
		Vector3 start = new Vector3 (orig.position.x, orig.position.y + Random.Range(orig.position.y, orig.position.y-3f), orig.position.z);
		//Debug.Log("hola");
		
		Cardu = Instantiate(cars[Random.Range(0,cars.Length)], orig.position, Quaternion.identity) as GameObject;
		Cardu.transform.localScale = new Vector3 (1, 1, 1);
		Cardu.transform.SetParent (panel);
		Cardu.GetComponent<cotxes> ().speed = Random.Range (1000.0f, 300.0f);
		Debug.Log(Cardu.GetComponent<cotxes> ().speed);
		
		
	}
}
