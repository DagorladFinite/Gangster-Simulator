using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public Sprite[] cossos;
	public Sprite[] cares;
	public GameObject Cara;
	public GameObject[] Cos;
	public float Posx;
	int rand;

    // Use this for initialization
    void Start () {
		
	
			//Posx = Random.Range (625.0f, 640.0f);
		GameObject cares1 = Instantiate (Cara,new Vector3(transform.position.x,transform.position.y ,transform.position.z),transform.rotation) as GameObject;
			cares1.GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
			cares1.transform.SetParent(transform);
			rand = Random.Range (0,8);
        GameObject cossos1 = Instantiate (Cos[rand],new Vector3(transform.position.x,transform.position.y-0.30f,transform.position.z),transform.rotation) as GameObject;
			//cossos1.GetComponent<SpriteRenderer>().sprite = cossos[rand];
		//cossos1.GetComponent<Animation> ().Play ();
		cossos1.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			cossos1.transform.SetParent(transform);
        
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void change() {
		transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
		transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = cossos[Random.Range (0,8)];
		int Posx = Random.Range(-6, 6);
		Vector2 pos = new Vector2(Posx+Random.Range(-0.2f,0.2f),transform.position.y);
		transform.position = pos;

	}
  
}
