using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioClip[] audios;
	public AudioSource source;
	//private float overlap = 0.2F;
	private int[] len = new int[5];



	// Use this for initialization
	void Start () {
		for (int i = 0; i<audios.Length; i++)
		{
			len[i] = audios[i].samples;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (source.isPlaying == false) {
			int rand = Random.Range(0,audios.Length);
			source.clip = audios[rand];
			double t0 = AudioSettings.dspTime - 0.1f;
			double clipTime1 = len[rand];
			clipTime1 /= audios[1].frequency;
			source.PlayScheduled(t0);
			source.SetScheduledEndTime(t0 + clipTime1);

		}
	}


}
