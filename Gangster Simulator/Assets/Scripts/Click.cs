﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text GoldDisplay;
	public UnityEngine.UI.Text mpc;
	public float gold = 0.00f;
	public int goldperclick = 1;
	public double karma = 0;
	public UnityEngine.UI.ScrollRect SR;
	public UnityEngine.UI.ScrollRect SR2;
	public UnityEngine.CanvasGroup pp;

	public bool popup1 = false; 
	public bool popup2 = false; 
	public bool canclick = true;
	public Texture aTexture;
	public Texture aTexture2;
	private float time = 0;
	private GameObject[] items;
	private GameObject[] labels;
	private GameObject[] upgrades;


	void Start(){
		items = GameObject.FindGameObjectsWithTag ("Item") as GameObject[];
		labels = GameObject.FindGameObjectsWithTag ("Label") as GameObject[];
	
	}

	//GUI.Button(new Rect(10, 20, 100, 20), "Hello World");

	void Update(){
		GoldDisplay.text = "Money: " + gold.ToString("F0") + " filthy coins";
		mpc.text = goldperclick + " Money/click";
		checkifpopup1 ();
		checkifpopup2 ();
		if (Input.GetKey ("escape")) {
			Save();
			Application.Quit ();
		}

		if (Input.GetKey ("l")) {
			load ();
		}
	}

	public void Clicked(){
		if (canclick == true) {
			gold += goldperclick;
		}

	}
	void OnGUI() {
		if (popup1) {


			Rect windowRect = new Rect (Screen.width / 3, Screen.height / 3, 500, 650);
			windowRect.center = new Vector2 (Screen.width / 2, Screen.height / 2);
			windowRect = GUI.Window (0, windowRect, click_popup, "POPUP1");
			GUI.DrawTexture (windowRect, aTexture, ScaleMode.ScaleToFit, false, 0.0f);



			canclick = false;
			Time.timeScale = 0;
			SR.enabled = false;
			SR2.enabled = false;


		
		}
		if (popup2) {


			Rect windowRect = new Rect(Screen.width / 3, Screen.height / 3, 500, 650);
			windowRect.center = new Vector2(Screen.width / 2, Screen.height / 2);
			windowRect = GUI.Window (0, windowRect, click_popup, "POPUP2");
			GUI.DrawTexture(windowRect, aTexture2, ScaleMode.ScaleToFit, false, 0.0f);


			canclick = false;
			Time.timeScale = 0;
			SR.enabled = false;
			SR2.enabled = false;


		}
	}
	public void click_popup(int windowID) {
		if (GUI.Button (new Rect (130, 425, 250, 100), "Click Me!")) {
			popup1 = false;
			popup2 = false;
			canclick = true;
			Time.timeScale = 1;
			SR.enabled = true;
			SR2.enabled = true;
		}
	}

	void checkifpopup1()
	{ 
		int random = UnityEngine.Random.Range (0, 10000);
		if (karma >= 50 && random <= 50 && Time.time - time > UnityEngine.Random.Range (10, 20)){// && Time.time - time > UnityEngine.Random.Range (60, 600)) {
			popup1 = true;
			time = Time.time;
		} 

	}

	void checkifpopup2()
	{
		int random = UnityEngine.Random.Range (0, 10000);
		if (karma <= -50 && random <= 50 && Time.time - time > UnityEngine.Random.Range (60, 600)) {
			popup2 = true;
			time = Time.time;
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
			Debug.Log ("I: " +  i);
			Debug.Log ("Script id: "+ script.id);
			Debug.Log ("Script count: "+ script.count);
			upgrade.id = script.id;
			upgrade.amount = script.count;
			data.upg.Add(upgrade);	

			Debug.Log ("Upgrade id: " + upgrade.id);
			Debug.Log ("Upgrade amount: " + upgrade.amount);

		}
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
		}
		}
	public void cheat(){
		gold = gold + 10000;
	}

	public void settings(){
		pp.alpha = 100;
		pp.blocksRaycasts = true;
		pp.interactable = true;
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
	public List<Items> itemsz = new List<Items> ();
	public List<Labels> labs = new List<Labels> ();
	public List<Upgrades> upg = new List<Upgrades> ();
}
