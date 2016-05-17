using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {
	public GameObject Bird;
	GameObject Berdu;
	public GameObject BirdBrown;
	GameObject BerduBrown;
	public sprite bird;
	float timer = 0;
	float timer2 = 0;
	public Transform panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timer >= Random.Range (10,19)) {
			timer = Time.time;
			SpawnBird();
//			Debug.Log("Hola");
		
		}

		if (Time.time - timer2 >= Random.Range (15,23)) {
			timer2 = Time.time;
			SpawnBirdBrown();
						//Debug.Log("Hola");
			
		}
	
	}

	public void SpawnBird(){
		Random.seed = (int)Time.time;
		Vector3 start = new Vector3 (Bird.GetComponent<sprite>().start.x,Bird.GetComponent<sprite>().start.y + Random.Range (-2,15),Bird.GetComponent<sprite>().start.z);
		//Debug.Log(start);
		Berdu = Instantiate(Bird, start, Quaternion.identity) as GameObject;
		Berdu.transform.localScale = new Vector3 (1, 1, 1);
		Berdu.transform.SetParent (panel);



	}

	public void SpawnBirdBrown(){
		Random.seed = (int)System.DateTime.Now.Ticks-20;
		Vector3 start2 = new Vector3 (BirdBrown.GetComponent<sprite>().start.x,BirdBrown.GetComponent<sprite>().start.y + Random.Range (-3,20),BirdBrown.GetComponent<sprite>().start.z);
		//Debug.Log(start2);
		BerduBrown = Instantiate(BirdBrown, start2, Quaternion.identity) as GameObject;
		BerduBrown.transform.localScale = new Vector3 (1, 1, 1);
		BerduBrown.transform.SetParent (panel);
	}
}
