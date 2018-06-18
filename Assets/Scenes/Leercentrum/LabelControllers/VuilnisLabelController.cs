using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VuilnisLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonVuilnis"))
        {
            descriptionText.text = "Alle buren hebben op de ophaaldag hun vuilnisbakken netjes aan straat staan. Waarom bij dit huis niet? Zijn ze de droom van elke milieuactivist en maken ze geen afval? Of hebben ze ‘bijzonder’ afval waarvan ze niet willen dat mensen dit zien?";
        }
    }
}
