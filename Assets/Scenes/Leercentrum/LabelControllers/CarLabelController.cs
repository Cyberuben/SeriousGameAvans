using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLabelController : MonoBehaviour {
    public Text descriptionText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonCar"))
        {
            descriptionText.text = "Dit autobedrijf doet kennelijk niks met auto’s. Dit kan betekenen dat dit bedrijf er een andere boekhouding op nahoudt.";
        }
    }
}
