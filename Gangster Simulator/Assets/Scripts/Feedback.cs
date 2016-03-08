using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class Feedback : MonoBehaviour {
	//public GameObject click;
	public Text text;
	public double input;
    private GameObject meta;
    public float time;
	int duracio = 20;
	int dur = 100;
	public int SortLayer = 0;
	//public int SortingLayerID = SortingLayer.GetLayerValueFromName("Pjs");
    // Use this for initialization
    void Start()
    {
		Renderer renderer = this.gameObject.GetComponent<Renderer>();
		if(renderer != null)
		{
			renderer.sortingOrder = SortLayer;
			renderer.sortingLayerName = "Backgrounds2";

		}
        //Click click = transform.Find ("Click").GetComponent<Click> () as Click;
        text.text = FormatNumber(input);//click.goldperclick.ToString();
		Vector2 rand = new Vector2(UnityEngine.Random.Range(-75, 75), UnityEngine.Random.Range(100, 300));
        this.GetComponent<Rigidbody2D>().AddForce(rand);
        //transform.rotation = transform.rotation * Quaternion.Euler(Random.Range(-10,10),0,0);
        meta = GameObject.Find("GoldDisplay");
    }
	// Update is called once per frame
	void Update () {
        if (duracio <= 0)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, meta.transform.position, time);
            transform.position = pos;

            if (dur == 0)
            { 
				Destroy(gameObject);
				dur = 75;
				//Destroy(gameObject); transform.position.y == meta.transform.position.y
			}
			dur--;
        }

        else
            duracio--;
        /*
		if (duracio <= 0)
			Destroy (gameObject);
		else
			duracio--;
            */
	}
	private string  FormatNumber(double value)
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
}
