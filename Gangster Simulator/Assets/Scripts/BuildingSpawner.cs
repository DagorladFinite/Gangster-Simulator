using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

	public GameObject Building;
	public Sprite[] Buildings;
	public int num_buildings;

	// Use this for initialization
	void Start () {
		//GameObject[] buildings;
		float off = (20 / num_buildings);
		float position = off-12;
		int counter = 0;
		for (int i = 0; i<num_buildings; i++) {
				//float Posy = Random.Range (2.5f, 5.0f);
				float Posx = Random.Range (-0.2f, 0.2f);
				Building = Instantiate (Building, new Vector3 (position + Posx, 2, 0), Building.transform.rotation) as GameObject;
				//float Range = Random.Range(2,4);
				Building.transform.localScale = new Vector3 (3,3,1);
				int sprite= Random.Range (0,Buildings.Length);

				if (sprite == 4 && counter <=2)
			{
				counter++;
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
			}
			else if (sprite == 4 && counter >2)
			{
				while (sprite ==4)
				{
					sprite= Random.Range (0,Buildings.Length);
				}
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
			}
			else{
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
			}
				Building.transform.SetParent(transform);
				position = position+off;
				//buildings[i] = Building;
			}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
