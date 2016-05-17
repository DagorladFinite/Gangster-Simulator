using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour {

	public GameObject Building;
	public GameObject BuildingBack;
	public SpriteRenderer cam;
	public UnityEngine.UI.Button moon;
	public GameObject Building2;
	public GameObject Building3;
	public Sprite[] Buildings;
	public Sprite[] Buildings_night;
	public Sprite[] Buildings_lights;
	public int num_buildings;
	public SpriteRenderer[] lamps;
	public SpriteRenderer[] bars;
	public SpriteRenderer street;
	public Sprite lamps1;
	public Sprite lamps2;
	private GameObject[] buildings2;
	private GameObject[] buildings3;
	private GameObject[] buildings4;
	//private GameObject[] nuvols;
	//private float time;
	public Color color;
	Color orig_color2;
	Color orig_color3;
	public Color skycolor;
	public Color nuvolcolor;
	public SpriteRenderer sky;
	public Color lerpedColor = Color.white;
	float duration = 15; // This will be your time in seconds.
	float duration2 = 10;
	float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
	Color currentColor = Color.white;
	Color orig_color;
	Color orig_sky;
	//Color orig_nuvol;
	Color orig_cam;
	//Color street_color;
	//int count = 0;
	public int day = 0;
	public AudioSource birds;
	//public AudioSource city;
	Color moon_orig;
	int rand;
	bool redmoon = false;
	Color moonco = Color.white;
	private float timer = 0;

	public Click click;


	// Use this for initialization
	void Start () {
		//GameObject[] buildings;

		moon_orig = moon.image.color;
		float off = (22 / num_buildings);
		float position = off-12;
		int counter = 0;
		for (int i = 0; i<num_buildings; i++) {
				//float Posy = Random.Range (2.5f, 5.0f);
				float Posx = Random.Range (-0.02f, 0.02f);
				Building = Instantiate (Building, new Vector3 (position + Posx, 5.0f, 0), Building.transform.rotation) as GameObject;
				Building2 = Instantiate (Building2, new Vector3 (position + Posx, 5.0f, 0), Building.transform.rotation) as GameObject;
				Building3 = Instantiate (Building3, new Vector3 (position + Posx, 5.0f, 0), Building.transform.rotation) as GameObject;
				BuildingBack = Instantiate (BuildingBack, new Vector3 (position - 5 + Posx+2, 5.0f, 0), Building.transform.rotation) as GameObject;
				//float Range = Random.Range(2,4);
				Building.transform.localScale = new Vector3 (0.5f,0.7f,0.5f);
				Building2.transform.localScale = new Vector3 (0.5f,0.7f,0.5f);
				Building3.transform.localScale = new Vector3 (0.5f,0.7f,0.5f);
				BuildingBack.transform.localScale = new Vector3 (0.8f,1.0f,0.5f);
				int sprite= Random.Range (0,Buildings.Length);

				BuildingBack.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];

				if (sprite == 4 && counter <=2)
			{
				counter++;
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
				Building2.GetComponent<SpriteRenderer>().sprite = Buildings_night[sprite];
				Building3.GetComponent<SpriteRenderer>().sprite = Buildings_lights[sprite];
				//BuildingBack.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
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
				//BuildingBack.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
			}
			else{
				Building.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
				Building2.GetComponent<SpriteRenderer>().sprite = Buildings_night[sprite];
				Building3.GetComponent<SpriteRenderer>().sprite = Buildings_lights[sprite];
				//BuildingBack.GetComponent<SpriteRenderer>().sprite = Buildings[sprite];
			}
				Building.transform.SetParent(transform);
				Building2.transform.SetParent(transform);
				Building3.transform.SetParent(transform);
				BuildingBack.transform.SetParent(transform);
				position = position+off;
				//buildings[i] = Building;
			}
		buildings2 = GameObject.FindGameObjectsWithTag ("Building") as GameObject[];
		buildings3 = GameObject.FindGameObjectsWithTag ("Building_night") as GameObject[];
		buildings4 = GameObject.FindGameObjectsWithTag ("Building_lights") as GameObject[];
		//nuvols = GameObject.FindGameObjectsWithTag ("Nuvol") as GameObject[];
	//	StartCoroutine("LerpColor");
		//BuildingBack.GetComponent<SpriteRenderer> ().color = Color.black;
	//	time = Time.time;

		orig_color = buildings2 [1].GetComponent<SpriteRenderer> ().color;
		orig_color2 = buildings3 [1].GetComponent<SpriteRenderer> ().color;
		orig_color3 = buildings4 [1].GetComponent<SpriteRenderer> ().color;

		orig_sky = sky.color;
		//orig_nuvol = nuvols [1].GetComponent<SpriteRenderer> ().color;
		//street_color = street.color;

		StartCoroutine("LerpColor");


		//sky.color = currentColor;
	}
	void Update(){
	

		rand = Random.Range (0, 10000);
		if (rand <= 5 && day == 1 && redmoon == false && Time.time - timer >= 1000) {
			timer = Time.time;
			moon.image.color = Color.red;
			redmoon = true;
			//StopCoroutine ("LerpColor");
			//StopCoroutine ("LerpColor2");

		}

	
	}

	public void Redmoon()
	{
		Debug.Log ("hola");
		if (redmoon == true) {
			StartCoroutine ("LerpMoon");
		}
	}

	IEnumerator LerpMoon()
	{

		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration2;
		click.multiplier += 1.5f;
		click.shake = true;
		while (progress < 1) {

			moonco = Color.Lerp(Color.red, moon_orig, progress);
			moon.image.color = moonco;
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		redmoon = false;
		click.multiplier -= 1.5f;
		click.shake = false;
		yield return true;
		//StartCoroutine ("LerpColor2");

	}

	IEnumerator LerpColor()
	{

		//Debug.Log ("Hola");
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		while(progress < 1)
		{
			sky.color = currentColor;
			cam.color = currentColor;
			street.color = currentColor;
			birds.volume = Mathf.Lerp (0.4f,0,progress);
			//city.volume = Mathf.Lerp (0.4f,0.1f,progress);
			//Debug.Log ("Hola");
			currentColor = Color.Lerp(orig_sky, skycolor, progress);
			moon.image.color = new Color(moon.image.color.r, moon.image.color.g, moon.image.color.b, Mathf.Lerp(0,1,progress));

			for (int j = 0; j<bars.Length;j++)
			{
				bars[j].color = currentColor;
			}

			for (int i = 0; i<num_buildings; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				//orig_color.a 
				Color newColor3 = new Color(orig_color.r, orig_color3.g, orig_color3.b, 0);
				buildings4[i].GetComponent<SpriteRenderer>().color = newColor3;
				Color newColor = new Color(orig_color.r, orig_color.g, orig_color.b, Mathf.Lerp(1,0,progress));
				buildings2[i].GetComponent<SpriteRenderer>().color = newColor;
				Color newColor2 = new Color(orig_color2.r, orig_color2.g, orig_color2.b, Mathf.Lerp(0.1f,1,progress));
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
		for (int i=0; i<lamps.Length;i++)
		{
			lamps[i].sprite = lamps2;
		}
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
			cam.color = currentColor;
			street.color = currentColor;
			birds.volume = Mathf.Lerp (0,0.4f,progress);
			//city.volume = Mathf.Lerp (0.1f,0.4f,progress);
			for (int j = 0; j<bars.Length;j++)
			{
				bars[j].color = currentColor;
			}
			//cam.backgroundColor = currentColor;
			//Debug.Log ("Hola");
			moon.image.color = new Color(moon.image.color.r, moon.image.color.g, moon.image.color.b, Mathf.Lerp(1,0,progress));
			currentColor = Color.Lerp(skycolor, orig_sky, progress);
			for (int i = 0; i<num_buildings; i++) {
				//lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
				
				Color newColor = new Color(orig_color.r, orig_color.g, orig_color.b, Mathf.Lerp(0.1f,1,progress));
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
		for (int i=0; i<lamps.Length;i++)
		{
			lamps[i].sprite = lamps1;
		}
		yield return new WaitForSeconds(10);
		StartCoroutine("LerpColor");
	}


}
