using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Analytics;



public class Click : MonoBehaviour {

	public FTE fte;
	public bool fte1 = false;
	public bool fte2 = false;
	public bool fte2Arrow = false;
	public bool fte3 = false;
	public bool fte3Arrow = false;
	public bool fte4 = false;
	public bool fte4Arrow = false;
	public bool fte5 = false;
	public GameObject arrow;
	public double buyitemcost;
	public double buyupgradecost;
	public double karmalimit;
	public GameObject terrain;
	public GameObject dealer;

	public UnityEngine.UI.Text GoldDisplay;
	public UnityEngine.UI.Text mpc;
	public double gold = 0;
	public int goldperclick = 1;
	public double karma = 0;
	public UnityEngine.UI.ScrollRect SR;
	public UnityEngine.UI.ScrollRect SR2;
	public UnityEngine.CanvasGroup pp;
	public UnityEngine.CanvasGroup pp2;
	public UnityEngine.CanvasGroup po;
	public UnityEngine.CanvasGroup pu;
	public UnityEngine.CanvasGroup bar;
	public Feedbacker Feedbacker;
	public BuildingSpawner BS;
    public SpawnManager SpawnManager;
	public DateTime date;
	public TimeSpan difference;

	public bool popup1 = false; 
	public bool popup2 = false; 
	public bool canclick = true;
	public Texture aTexture;
	public Texture aTexture2;
	private float time = 0;
	private GameObject[] items;
	private GameObject[] labels;
	private GameObject[] upgrades;
	public bool set = false;
	public GameObject feedback;
    private List<GameObject> pjs;
    private GameObject[] pjss;
	private GameObject[] pjss2;
    public float extra = 0;
	GameObject fed;
	//int p = 0;
	public float multiplier = 1.0f;
    public float multiplier2 = 1.0f;
    public float duration;
    public float magnitude;
    public bool shake;
	public GameObject[] pisos;
	bool barshow = false;
	public int pis_current = 0;
	public int buyings = 0;
    public Extra extratext;

	public Popups pop1;
	public Popups2 pop2;

    public GameObject extrapanel;
	public GameObject credits;

	public AudioSource CoinSound;
	public Camera cam;

	public bool autoload;

    void Start(){

		items = GameObject.FindGameObjectsWithTag ("Item") as GameObject[];
		labels = GameObject.FindGameObjectsWithTag ("Label") as GameObject[];
		upgrades = GameObject.FindGameObjectsWithTag ("Upgrade") as GameObject[];
        pjs = new List<GameObject>();
		date = System.DateTime.Now;
		if (autoload == true) {
			load();
		}
		//Debug.Log (date);
        //Calc();
		//Save ();
		if (fte1 == false && fte2 == false && fte3 == false) {
			//upgrades = GameObject.FindGameObjectsWithTag ("Upgrade") as GameObject[];
			for (int i = 0; i<upgrades.Length;i++)
			{
				upgrades[i].SetActive(false);
			}
			if( fte4 == false){
				dealer.SetActive(false);
			}
		}

		for (int i = 0; i < pis_current; i++) {
			pisos[i].SetActive(true);
		}


    }

	//GUI.Button(new Rect(10, 20, 100, 20), "Hello World");

	void Update(){
		if (fte1 == false) {
			canclick = false;
			fte1 = true;
			fte.Part1();
		//	Save ();
		
		}

		if (fte1 == true && fte2 == false && gold >= buyitemcost) {
			canclick = false;
			fte2 = true;
			fte.Part2();
			//Save ();
		}

		if (fte2 == true && fte3 == false && gold >= buyupgradecost && fte2Arrow == true) {
			fte3 = true;
			for (int i = 0; i<upgrades.Length;i++)
			{
				upgrades[i].SetActive(true);
			}
			canclick = false;

			fte.Part3();
			//Save ();
		}

		if (fte3 == true && fte4 == false && fte3Arrow == true && (karma >= karmalimit || karma <= -karmalimit )) {
			fte4 = true;
			dealer.SetActive(true);
			//arrow.transform.SetParent(terrain.transform);
			canclick = false;
			
			fte.Part4();
		//	Save ();
		}

		if (fte4 == true && fte5 == false && pis_current >=3 ) {
			fte5 = true;
			//dealer.SetActive(true);
			//arrow.transform.SetParent(terrain.transform);
			canclick = false;
			
			fte.Part5();
			Save ();
		}







		GoldDisplay.text = "Money: " + FormatNumber (gold);
			//gold.ToString("F0") ;
		mpc.text = FormatNumber(goldperclick*multiplier) + " Money/click";
		checkifpopup1 ();
		checkifpopup2 ();
		if (Input.GetKeyDown ("escape")) {
			Save();
			Analytics.CustomEvent("quit", new Dictionary<string, object>
			{
				{ "gold", gold },
				{ "karma", karma },
			});
			Gender gender = Gender.Female;
			Analytics.SetUserGender(gender);
			int birthYear = 2014;
			Analytics.SetUserBirthYear(birthYear);
			Application.Quit ();
		}

		if (Input.GetKey ("l")) {
			load ();
		}

		switch (BS.day) {
		case 0:
			multiplier = 1.1f;
            multiplier2 = 0.8f;
			break;
		case 1:
			multiplier = 0.8f;
            multiplier2 = 1.1f;
            break;

		}
	}
	public void barr(){
		if (canclick == true) {
			if (barshow == false) {
				if(fte2Arrow == false){
					fte2Arrow = true;
					arrow.SetActive(false);
				}
				bar.alpha = 1;
				bar.blocksRaycasts = true;
				bar.interactable = true;
				barshow = true;
				//Debug.Log("Enabled");
			} else if (barshow == true) {
				bar.alpha = 0;
				bar.blocksRaycasts = false;
				bar.interactable = false;
				barshow = false;
				//Debug.Log("Disabled");
			}
		}

	}
	public string  FormatNumber(double value)
	{
		string[]  suffixes = new string[] {" K", " M", " B", " T", " Q"};
		for (int j = suffixes.Length;  j > 0;  j--)
		{
			double  unit = Math.Pow(1000, j);
			if (value >= unit)
				return (value / unit).ToString("#,##0.0") + suffixes[--j];
		}
		return value.ToString("#,##0");
	}

   public void Calc()
    {
        pjss = GameObject.FindGameObjectsWithTag("Character") as GameObject[];
        foreach (GameObject obj in pjss)
        {
            pjs.Add(obj);
            //Debug.Log(pjs.ToArray().Length);
        }
       // Debug.Log(pjs.ToArray().Length);

    }

	public void Clicked(){
		if (canclick == true) {
          
            gold += goldperclick * multiplier;
			Feedbacker.Spawn();

            if (pjs.Count < 5)
            {
                SpawnManager.Spawnerd();
            }
            //Debug.Log(pjs[0]);
            int random = UnityEngine.Random.Range(0, 30);
            if (pjs[0] != null && random>20)
            {
                pjs[0].GetComponent<MovementCos>().StartMove();
                pjs.RemoveAt(0);
            }
            else if (pjs[0] == null)
            {
                pjs = new List<GameObject>();
                Calc();
            }
			CoinSound.Play();
            //Debug.Log(p);
            //SpawnManager.Spawn();
            // pjs.Add(SpawnManager.Spawn());
           
		}
        if (shake == true)
        {
            StartCoroutine(Shake());
        }
	}


	void checkifpopup1()
	{ 
		int random = UnityEngine.Random.Range (0, 10000);
		if (karma >= 50 && random <= 50 && Time.time - time > UnityEngine.Random.Range (60, 600)&& set == false){// && Time.time - time > UnityEngine.Random.Range (60, 600)) {
			popup1 = true;
			time = Time.time;
			//canclick = false;
			Time.timeScale = 0;
			SR.enabled = false;
			//SR2.enabled = false;
			popups();
		} 

	}

	void checkifpopup2()
	{
		int random = UnityEngine.Random.Range (0, 10000);
		if (karma <= -50 && random <= 50 && Time.time - time > UnityEngine.Random.Range (60, 600) && set == false) {

			time = Time.time;
			//canclick = false;
			Time.timeScale = 0;
			SR.enabled = false;
			//SR2.enabled = false;
			popups2();
		}
	}
	public void Credits(){
		credits.SetActive (true);
	}
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();

		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
		PlayerData data = new PlayerData ();
		data.gold = gold;
		data.goldperclick = goldperclick;
		data.karma = karma;
		for (int i=0; i<items.Length; i++) {
			Items item = new Items ();
			UpgradeManager script = items[i].GetComponent<UpgradeManager>();
			item.id = script.id;
			item.amount = script.count;
			data.itemsz.Add(item);	

		}
		for (int i=0; i<labels.Length; i++) {
			Labels label = new Labels ();
			LayerManager script = labels[i].GetComponent<LayerManager>();
			label.purchased = script.purchased;
			data.labs.Add(label);		
		}
		upgrades = GameObject.FindGameObjectsWithTag ("Upgrade") as GameObject[];
		for (int i=0; i<upgrades.Length; i++) {
			Upgrades upgrade = new Upgrades ();
			ItemManager script = upgrades[i].GetComponent<ItemManager>();
			//Debug.Log ("I: " +  i);
			//Debug.Log ("Script id: "+ script.id);
			//Debug.Log ("Script count: "+ script.count);
			upgrade.id = script.id;
			upgrade.amount = script.count;
			data.upg.Add(upgrade);	

			//Debug.Log ("Upgrade id: " + upgrade.id);
			//Debug.Log ("Upgrade amount: " + upgrade.amount);

		}
		Debug.Log ("SAVED");
		data.fte1 = fte1;
		data.fte2 = fte2;
		data.fte3 = fte3;
		data.fte4 = fte4;
		data.fte5 = fte5;
		data.fte2Arrow = fte2Arrow;
		data.fte3Arrow = fte3Arrow;
        data.extra = extra;
		data.date = date.ToBinary().ToString();
		data.upg.ToArray ();
		data.itemsz.ToArray ();
		data.pis_current = pis_current;
		bf.Serialize (file, data);

		file.Close ();
	}

	public void Reset(){
		Save ();
		gold = 0;
		goldperclick = 1;
		karma = 0;
        int tempcount2 = 0;
        int tempcount = 0;

		for (int i=0; i<items.Length; i++) {
			UpgradeManager script = items [i].GetComponent<UpgradeManager> ();
			//script.id = data.itemsz [i].id;
			tempcount += script.count;
			script.count = 0;
           
		}

		upgrades = GameObject.FindGameObjectsWithTag ("Upgrade") as GameObject[];
		
		for (int i=0; i<upgrades.Length; i++) {
			for (int j=0; j<upgrades.Length;j++){
				ItemManager script = upgrades [j].GetComponent<ItemManager> ();
                tempcount2 += script.count;
					script.count = 0;
                    script.reset();
					//Debug.Log (script.count);
				}
			}
			
		for (int i = 0; i < pisos.Length; i++) {
			pisos[i].SetActive(false);
		}
		pis_current = 0;
		GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
		for (int i= 0; i<pjs.Length; i++) {
			SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer rnd in rend)
				rnd.enabled = true;
			
			
		}
		set = false;
		pp.alpha = 0;
		pp.blocksRaycasts = false;
		pp.interactable = false;
		canclick = true;
        extra += (tempcount * 0.01f) + (tempcount2 * 0.04f);
		extrapanel.SetActive(true);
        extratext.Updateextra();
        
	}

	public void load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			gold = data.gold;
			goldperclick = data.goldperclick;
			karma = data.karma;
			for (int i=0; i<items.Length; i++) {
				UpgradeManager script = items [i].GetComponent<UpgradeManager> ();
				script.id = data.itemsz [i].id;
				script.count = data.itemsz [i].amount;
				//Debug.Log (i);
			}
			for (int i=0; i<labels.Length; i++) {
				LayerManager script = labels [i].GetComponent<LayerManager> ();
				if (data.labs [i].purchased == true)
					script.PurchasedLoad ();
			}
			upgrades = GameObject.FindGameObjectsWithTag ("Upgrade") as GameObject[];

				for (int i=0; i<upgrades.Length; i++) {
					for (int j=0; j<upgrades.Length;j++){
						ItemManager script = upgrades [j].GetComponent<ItemManager> ();
							if (script.id == data.upg[i].id){
							script.count = data.upg [i].amount;
							//Debug.Log (script.count);
							}
				}
				

			}
			fte1 = data.fte1;
			fte2 = data.fte2;
			fte3 = data.fte3;
			fte4 = data.fte4;
			fte5 = data.fte5;
			fte2Arrow = data.fte2Arrow;
			fte3Arrow = data.fte3Arrow;
			long temp = Convert.ToInt64(data.date);
			pis_current = data.pis_current;
			DateTime oldDate = DateTime.FromBinary(temp);
			difference = date.Subtract(oldDate);
			Debug.Log("Difference: " + difference);
            extra = data.extra;
			Offline ();

		}
		}
	void OnApplicationQuit() {
		Save ();
	}
	public void cheat(){
		gold = gold + 10000;
	}

	public void Offline(){
			double temp = (difference.TotalSeconds * gold) * 0.00005 ;
			gold = gold + temp;
			fte.Offline(temp);

		 /*else if (difference.TotalSeconds > 20) {
			double temp = 10000;
			gold = gold + 10000;
			fte.Offline(temp);
		}*/
	
	}

	public void settings(){
		if (canclick == true) {
			GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
			for (int i= 0; i<pjs.Length; i++) {
				SpriteRenderer[] rend = pjs [i].GetComponentsInChildren<SpriteRenderer> ();
				foreach (SpriteRenderer rnd in rend)
					rnd.enabled = false;
			
			
			}
			set = true;
			pp.alpha = 100;
			pp.blocksRaycasts = true;
			pp.interactable = true;
			canclick = false;
		}
	}
	public void broker(){
		if (canclick == true) {
			/*
			if(fte4Arrow == false)
			{
				fte4Arrow = true;
				arrow.SetActive(false);
			}
*/
		GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
		for (int i= 0; i<pjs.Length; i++) {
			SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer rnd in rend)
				rnd.enabled = false;
			
			
		}
		set = true;
		pp2.alpha = 100;
		pp2.blocksRaycasts = true;
		pp2.interactable = true;
		canclick = false;
		}
	}


public void popups(){
	GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
	for (int i= 0; i<pjs.Length; i++) {
		SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer rnd in rend)
			rnd.enabled = false;
		
		
	}
		pop1.UpdateText ();
	po.alpha = 100;
	po.blocksRaycasts = true;
	po.interactable = true;
	canclick = false;
}
	public void popups2(){
		GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
		for (int i= 0; i<pjs.Length; i++) {
			SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer rnd in rend)
				rnd.enabled = false;
			
			
		}
		pop2.UpdateText ();
		pu.alpha = 100;
		pu.blocksRaycasts = true;
		pu.interactable = true;
		canclick = false;
	}

    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = cam.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = UnityEngine.Random.value * 2.0f - 1.0f;
            float y = UnityEngine.Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            cam.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        cam.transform.position = originalCamPos;
    }
}



[Serializable]
public class Upgrades
{
	public int id;
	public int amount;
	
}
[Serializable]
public class Items
{
	public int id;
	public int amount;
	
}
[Serializable]
public class Labels
{
	public bool purchased;
	
}

[Serializable]
class PlayerData
{
	public double gold;
	public int goldperclick;
	public double karma;
    public float extra;
	public String date;
	public int pis_current;
	public bool fte1 = false;
	public bool fte2 = false;
	public bool fte2Arrow = false;
	public bool fte3 = false;
	public bool fte3Arrow = false;
	public bool fte4 = false;
	public bool fte5 = false;
	public List<Items> itemsz = new List<Items> ();
	public List<Labels> labs = new List<Labels> ();
	public List<Upgrades> upg = new List<Upgrades> ();
}
