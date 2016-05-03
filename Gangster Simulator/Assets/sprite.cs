using UnityEngine;
using System.Collections;

public class sprite : MonoBehaviour {

	Vector3 end;
	Vector3 start;

	// Use this for initialization
	void Start () {
		StartCoroutine(MoveObject(transform, 50.0f));
		end = new Vector3(transform.position.x - 20,transform.position.y, transform.position.z);
		start = new Vector3(transform.position.x,transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator MoveObject(Transform thisTransform, float time)
	{
		//bar = GameObject.FindGameObjectWithTag ("Bar") as GameObject;
		
		//Debug.Log(transform.position);
		float i = 0.0f;
		float rate = 1.0f / time;
		while (thisTransform.position != end) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp (thisTransform.position, end, i);
			//thisTransform.position.x = thisTransform.position.x
			yield return new WaitForSeconds (0.1f);
			
		}
		//Destroy(gameObject);
		thisTransform.position = start;
		Destroy(gameObject);
		yield return true;
	}



}
