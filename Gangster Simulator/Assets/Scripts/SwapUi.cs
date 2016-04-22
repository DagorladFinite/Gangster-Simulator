using UnityEngine;
using System.Collections;

public class SwapUi : MonoBehaviour {

	public UnityEngine.UI.Text text;
	public UnityEngine.UI.Image img;
	bool active = false;
	public Sprite sprite;
	public Sprite original;
	public GameObject arrow;
	public Sprite aleft;
	public Sprite aright;
	UnityEngine.UI.Image arrowsprite;

	// Use this for initialization
	void Start () {
		arrowsprite = arrow.GetComponent<UnityEngine.UI.Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void swap()
	{
		if (text.IsActive () == true) {
			text.gameObject.SetActive(false);
		}
		else if (text.IsActive () != true) {
			text.gameObject.SetActive(true);
		}

		if (active == false) {
			img.sprite = sprite;
			arrowsprite.sprite = aright;
			Vector2 temp;
			temp.x = arrow.transform.position.x - 1.7f;
			temp.y = arrow.transform.position.y;
			arrow.transform.position = temp;
			active = true;

		}
		else if (active == true) {
			img.sprite = original;
			arrowsprite.sprite = aleft;
			Vector2 temp;
			temp.x = arrow.transform.position.x + 1.7f;
			temp.y = arrow.transform.position.y;
			arrow.transform.position = temp;
			active = false;
		}
	
	}
}
