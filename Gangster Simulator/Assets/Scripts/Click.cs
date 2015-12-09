using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Analytics;



public class Click : MonoBehaviour {

	public UnityEngine.UI.Text GoldDisplay;
	public UnityEngine.UI.Text mpc;
	public float gold = 0.00f;
	public int goldperclick = 1;
	public double karma = 0;
	public UnityEngine.UI.ScrollRect SR;
	public UnityEngine.UI.ScrollRect SR2;
	public UnityEngine.CanvasGroup pp;
	public UnityEngine.CanvasGroup po;
	public UnityEngine.CanvasGroup pu;
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
	GameObject fed;
	int p = 0;
	public float multiplier = 1.0f;
    public float multiplier2 = 1.0f;

    void Start(){
		items = GameObject.FindGameObjectsWithTag ("Item") as GameObject[];
		labels = GameObject.FindGameObjectsWithTag ("Label") as GameObject[];
        pjs = new List<GameObject>();
		date = System.DateTime.Now;
		Debug.Log (date);
        //Calc();

    }

	//GUI.Button(new Rect(10, 20, 100, 20), "Hello World");

	void Update(){
		GoldDisplay.text = "Money: " + gold.ToString("F0") + " filthy coins";
		mpc.text = goldperclick*multiplier + " Money/click";
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
            //Debug.Log(p);
            //SpawnManager.Spawn();
            // pjs.Add(SpawnManager.Spawn());
           
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
			SR2.enabled = false;
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
			SR2.enabled = false;
			popups2();
		}
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
		data.date = date.ToBinary().ToString();
		data.upg.ToArray ();
		data.itemsz.ToArray ();
		bf.Serialize (file, data);
		file.Close ();
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
			long temp = Convert.ToInt64(data.date);
			DateTime oldDate = DateTime.FromBinary(temp);
			difference = date.Subtract(oldDate);
			Debug.Log("Difference: " + difference);
			Offline ();

		}
		}
	public void cheat(){
		gold = gold + 10000;
	}

	public void Offline(){
		if (difference.TotalSeconds > 10 && difference.TotalSeconds < 20) {
			gold = gold + 1000;
		} else if (difference.TotalSeconds > 20) {
			gold = gold + 10000;
		}
	
	}

	public void settings(){
		GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
		for (int i= 0; i<pjs.Length; i++) {
			SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer rnd in rend)
				rnd.enabled = false;
			
			
		}
		set = true;
		pp.alpha = 100;
		pp.blocksRaycasts = true;
		pp.interactable = true;
		canclick = false;
	}


public void popups(){
	GameObject[] pjs = GameObject.FindGameObjectsWithTag ("Character");
	for (int i= 0; i<pjs.Length; i++) {
		SpriteRenderer[] rend = pjs[i].GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer rnd in rend)
			rnd.enabled = false;
		
		
	}
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
		pu.alpha = 100;
		pu.blocksRaycasts = true;
		pu.interactable = true;
		canclick = false;
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
	public float gold;
	public int goldperclick;
	public double karma;
	public String date;
	public List<Items> itemsz = new List<Items> ();
	public List<Labels> labs = new List<Labels> ();
	public List<Upgrades> upg = new List<Upgrades> ();
}
