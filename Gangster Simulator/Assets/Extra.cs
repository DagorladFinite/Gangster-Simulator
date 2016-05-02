using UnityEngine;
using System.Collections;

public class Extra : MonoBehaviour {
    public UnityEngine.UI.Text text;
    public Click click;
    public GameObject panel;
    float extragold;

	// Use this for initialization
	void Start () {
        //Updateextra();
        text.text = "You got \n\n\n" + extragold + " \n\n\nextra gold income from your previous business";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void Updateextra()
    {
        extragold = click.extra;
    }
    public void hide()
    {
        panel.SetActive(false);
    }
}
