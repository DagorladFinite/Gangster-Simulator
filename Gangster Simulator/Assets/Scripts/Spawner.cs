using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public Sprite[] cossos;
	public Sprite[] cares;
	public GameObject Cara;
	public GameObject Cos;
	public float Posx;
    //GameObject cares1;
    //GameObject cossos1;

    // Use this for initialization
    void Start () {
		
	
			//Posx = Random.Range (625.0f, 640.0f);
		GameObject cares1 = Instantiate (Cara,new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation) as GameObject;
			cares1.GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
			cares1.transform.SetParent(transform);
        GameObject cossos1 = Instantiate (Cos,new Vector3(transform.position.x,transform.position.y - 0.40f,transform.position.z),transform.rotation) as GameObject;
			cossos1.GetComponent<SpriteRenderer>().sprite = cossos[Random.Range (0,8)];
			cossos1.transform.SetParent(transform);
        
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    public void Spawn()
    {
        cares1 = Instantiate(Cara, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
        cares1.GetComponent<SpriteRenderer>().sprite = cares[Random.Range(0, 16)];
        cares1.transform.SetParent(transform);
        cossos1 = Instantiate(Cos, new Vector3(transform.position.x, transform.position.y - 0.40f, transform.position.z), transform.rotation) as GameObject;
        cossos1.GetComponent<SpriteRenderer>().sprite = cossos[Random.Range(0, 8)];
        cossos1.transform.SetParent(transform);

    }*/
}
