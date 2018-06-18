using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JerrycanLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonJerrycans"))
        {
            descriptionText.text = "In opgerolde drugslabs worden vaak jerrycans zonder labels gevonden. Het vinden van jerrycans waar geen sticker op zit kan dus wijzen op de aanwezigheid van een drugslab.";
        }
    }
}
