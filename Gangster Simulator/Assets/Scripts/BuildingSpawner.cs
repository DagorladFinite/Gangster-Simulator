using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

	public GameObject Building;
	public Sprite[] Buildings;
	public int num_buildings;
	private GameObject[] buildings2;
	private GameObject[] nuvols;
	private float time;
	public Color color;
	public Color skycolor;
	public Color nuvolcolor;
	public SpriteRenderer sky;
	public Color lerpedColor = Color.white;
	float duration = 1; // This will be your time in seconds.
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	Color currentColor = Color.white;
	Color orig_color;
	Color orig_sky;
	Color orig_nuvol;
	int count = 0;

	// Use this for initialization
	void Start () {
		//GameObject[] buildings;


		float off = (20 / num_buildings);
		float position = off-12;
		int counter = 0;
		for (int i = 0; i<num_buildings; i++) {
				//float Posy = Random.Range (2.5f, 5.0f);
				float Posx = Random.Range (-0.2f, 0.2f);
				Building = Instantiate (Building, new Vector3 (position + Posx, 1.7f, 0), Building.transform.rotation) as GameObject;
				//float Range = Random.Range(2,4);
				Building.transform.localScale = new Vector3 (1,1,1);
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
		buildings2 = GameObject.FindGameObjectsWithTag ("Building") as GameObject[];
		nuvols = GameObject.FindGameObjectsWithTag ("Nuvol") as GameObject[];
		StartCoroutine("LerpColor");
		time = Time.time;

		orig_color = buildings2 [1].GetComponent<SpriteRenderer> ().color;
		orig_sky = sky.color;
		orig_nuvol = nuvols [1].GetComponent<SpriteRenderer> ().color;
	


		//sky.color = currentColor;
	}
	
	// Update is called once per frame
	void Update () {
			lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
		//sky.color = lerpedColor;
		if (Time.time - time > 10 && Time.time - time < 100) {
			for (int i = 0; i<num_buildings; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				
				buildings2[i].GetComponent<SpriteRenderer>().color = color;
				
			}
			for (int i = 0; i<nuvols.Length; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				nuvols[i].GetComponent<SpriteRenderer>().color = nuvolcolor;
				

			}
			sky.color = skycolor;
			count++;
		}

		if (count >= 10000) {
			for (int i = 0; i<num_buildings; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				
				buildings2[i].GetComponent<SpriteRenderer>().color = orig_color;
				
			}
			for (int i = 0; i<nuvols.Length; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				nuvols[i].GetComponent<SpriteRenderer>().color = orig_nuvol;
				
				
			}
			sky.color = orig_sky;
			time = 0.0f;
			count = 0;
		}
}
	IEnumerator LerpColor()
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		while(progress < 1)
		{
			//Debug.Log ("Hola");
			currentColor = Color.Lerp(Color.red, Color.blue, progress);
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		return true;
	}
}
