using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfRamenLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonAfRamen"))
        {
            descriptionText.text = "Als je niks te verbergen hebt, wil je natuurlijk veel liever het zonnetje door de ramen zien schijnen. Dit kan verdacht zijn.";
        }
    }
}
