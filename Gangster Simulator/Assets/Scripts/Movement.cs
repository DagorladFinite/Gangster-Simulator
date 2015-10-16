using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector2 endpoint;
	
	public float speed;
	public float counter;
	private float counter2;
	private int numberOfLoops = 1;
	
	void Update ()
	{
		counter2 -= Time.deltaTime;
		if (counter2 < 0 && numberOfLoops > 0) {
			RandomPosition ();
			numberOfLoops--;
			counter2 = counter;
		} else {
			int Rand = Random.Range (0,1000);
				if ( Rand<10)
			{
				RandomPosition ();
			}
		
		}
		
		transform.position = Vector2.Lerp(transform.position, endpoint, Time.deltaTime * speed);
	}
	
	void RandomPosition ()
	{
		float x = Random.Range(624.0f, 640.0f);
		float y = 183.65f;
		endpoint = new Vector2(x, y);
	}

}
