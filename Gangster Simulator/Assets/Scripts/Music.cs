using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioClip[] audios;
	public AudioSource source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (source.isPlaying == false) {
			source.clip = audios[Random.Range(0,audios.Length)];
			source.Play();
		}
	}
}
