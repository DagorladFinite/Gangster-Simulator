using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

	public GameObject Building;
	public GameObject Building2;
	public GameObject Building3;
	public Sprite[] Buildings;
	public Sprite[] Buildings_night;
	public Sprite[] Buildings_lights;
	public int num_buildings;
	private GameObject[] buildings2;
	private GameObject[] buildings3;
	private GameObject[] buildings4;
	private GameObject[] nuvols;
	private float time;
	public Color color;
	Color orig_color2;
	Color orig_color3;
	public Color skycolor;
	public Color nuvolcolor;
	public SpriteRenderer sky;
	public Color lerpedColor = Color.white;
	float duration = 10; // This will be your time in seconds.
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	Color currentColor = Color.white;
	Color orig_color;
	Color orig_sky;
	Color orig_nuvol;
	int count = 0;
	public int day = 0;

	// Use this for initialization
	void Start () {
		//GameObject[] buildings;


		float off = (22 / num_buildings);
		float position = off-12;
		int counter = 0;
		for (int i = 0; i<num_buildings; i++) {
				//float Posy = Random.Range (2.5f, 5.0f);
				float Posx = Random.Range (-0.02f, 0.02f);
				Building = Instantiate (Building, new Vector3 (position + Posx, 3.0f, 0), Building.transform.rotation) as GameObject;
				Building2 = Instantiate (Building2, new Vector3 (position + Posx, 3.0f, 0), Building.transform.rotation) as GameObject;
				Building3 = Instantiate (Building3, new Vector3 (position + Posx, 3.0f, 0), Building.transform.rotation) as GameObject;
				//float Range = Random.Range(2,4);
				Building.transform.localScale = new Vector3 (0.5f,0.7f,0.5f);
			Building2.transform.localScale = new Vector3 (0.5f,0.7f,0.5f);
			Building3.transform.localScale = new Vector3 (0.5f,0.7f,0.5f);
				int sprite= Random.Range (0,Buildings.Length);

				if (sprite == 4 && counter <=2)
			{
				counter++;
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
				Building2.GetComponent<SpriteRenderer>().sprite = Buildings_night[sprite];
				Building3.GetComponent<SpriteRenderer>().sprite = Buildings_lights[sprite];
			}
			else if (sprite == 4 && counter >2)
			{
				while (sprite ==4)
				{
					sprite= Random.Range (0,Buildings.Length);
				}
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
				Building2.GetComponent<SpriteRenderer>().sprite = Buildings_night[sprite];
				Building3.GetComponent<SpriteRenderer>().sprite = Buildings_lights[sprite];
			}
			else{
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
				Building2.GetComponent<SpriteRenderer>().sprite = Buildings_night[sprite];
				Building3.GetComponent<SpriteRenderer>().sprite = Buildings_lights[sprite];
			}
				Building.transform.SetParent(transform);
				Building2.transform.SetParent(transform);
				Building3.transform.SetParent(transform);
				position = position+off;
				//buildings[i] = Building;
			}
		buildings2 = GameObject.FindGameObjectsWithTag ("Building") as GameObject[];
		buildings3 = GameObject.FindGameObjectsWithTag ("Building_night") as GameObject[];
		buildings4 = GameObject.FindGameObjectsWithTag ("Building_lights") as GameObject[];
		nuvols = GameObject.FindGameObjectsWithTag ("Nuvol") as GameObject[];
	//	StartCoroutine("LerpColor");
		time = Time.time;

		orig_color = buildings2 [1].GetComponent<SpriteRenderer> ().color;
		orig_color2 = buildings3 [1].GetComponent<SpriteRenderer> ().color;
		orig_color3 = buildings4 [1].GetComponent<SpriteRenderer> ().color;

		orig_sky = sky.color;
		orig_nuvol = nuvols [1].GetComponent<SpriteRenderer> ().color;

		StartCoroutine("LerpColor");


		//sky.color = currentColor;
	}
	/*
	// Update is called once per frame
	void Update () {
			//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
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

			//StartCoroutine("LerpColor");
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
}*/
	IEnumerator LerpColor()
	{

		//Debug.Log ("Hola");
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		while(progress < 1)
		{
			sky.color = currentColor;
			//Debug.Log ("Hola");
			currentColor = Color.Lerp(orig_sky, skycolor, progress);
			for (int i = 0; i<num_buildings; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				//orig_color.a 
				Color newColor3 = new Color(orig_color.r, orig_color3.g, orig_color3.b, 0);
				buildings4[i].GetComponent<SpriteRenderer>().color = newColor3;
				Color newColor = new Color(orig_color.r, orig_color.g, orig_color.b, Mathf.Lerp(1,0,progress));
				buildings2[i].GetComponent<SpriteRenderer>().color = newColor;
				Color newColor2 = new Color(orig_color2.r, orig_color2.g, orig_color2.b, Mathf.Lerp(0,1,progress));
				buildings3[i].GetComponent<SpriteRenderer>().color = newColor2;
				
			}
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		yield return true;
		for (int i = 0; i<num_buildings; i++) {
			//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
			//orig_color.a 
			Color newColor3 = new Color (orig_color.r, orig_color3.g, orig_color3.b, 1);
			buildings4 [i].GetComponent<SpriteRenderer> ().color = newColor3;
		}
		day = 1;
		yield return new WaitForSeconds(10);
		StartCoroutine ("LerpColor2");
	}

	IEnumerator LerpColor2()
	{

		//Debug.Log ("Hola");
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		while(progress < 1)
		{
			sky.color = currentColor;
			//Debug.Log ("Hola");
			currentColor = Color.Lerp(skycolor, orig_sky, progress);
			for (int i = 0; i<num_buildings; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				
				Color newColor = new Color(orig_color.r, orig_color.g, orig_color.b, Mathf.Lerp(0,1,progress));
				buildings2[i].GetComponent<SpriteRenderer>().color = newColor;
				Color newColor2 = new Color(orig_color2.r, orig_color2.g, orig_color2.b, Mathf.Lerp(1,0,progress));
				buildings3[i].GetComponent<SpriteRenderer>().color = newColor2;
				
			}
			if ( progress >= 0.2)
			{
				for (int i = 0; i<num_buildings; i++) {
					//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
					//orig_color.a 
					Color newColor3 = new Color (orig_color.r, orig_color3.g, orig_color3.b, 0);
					buildings4 [i].GetComponent<SpriteRenderer> ().color = newColor3;
				}
			}
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		yield return true;
		day = 0;
		yield return new WaitForSeconds(10);
		StartCoroutine("LerpColor");
	}
}
