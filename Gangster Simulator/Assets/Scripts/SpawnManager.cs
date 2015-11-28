using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject Pj;
	 float Posx;
	public int max_quantity;
    public Click click;

	// Use this for initialization
	void Start () {

		/*GameObject g;
		GameObject d;
		g = Instantiate (Cara,new Vector3(Posx,183.60f,-0.69f),transform.rotation) as GameObject;
		g.GetComponent<SpriteRenderer>().sprite = cares[Random.Range (0,16)];
		d = Instantiate (Cos,new Vector3(Posx,183.12f,-0.69f),transform.rotation) as GameObject;
		d.GetComponent<SpriteRenderer>().sprite = cossos[Random.Range (0,8)];
		*/
		
		for (int i = 0; i<max_quantity; i++) {
            Posx = Random.Range(-6, 6);
            //Pj = Instantiate (Pj,new Vector3(Posx,183.65f,0.0f),transform.rotation) as GameObject;
            Pj = Instantiate (Pj,new Vector3(Posx+Random.Range(-0.2f,0.2f),0.5f,0.0f),transform.rotation) as GameObject;
			Pj.transform.SetParent(transform);
			//Posx = Posx+0.2f;
		
		}
        click.Calc();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject Spawn() {
        Posx = Random.Range(-6, 6);
        //Pj = Instantiate (Pj,new Vector3(Posx,183.65f,0.0f),transform.rotation) as GameObject;
        Pj = Instantiate(Pj, new Vector3(Posx, 0.5f, 0.0f), transform.rotation) as GameObject;
        Pj.transform.localScale = new Vector3(1, 1, 1);
        Pj.transform.SetParent(transform);
        //Posx = Posx+0.2f;
        return Pj;
    }
}
