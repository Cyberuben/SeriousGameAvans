using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MurenLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonMuren"))
        {
            descriptionText.text = "Wanneer muren abnormaal warm aanvoelen, bevind zich in de andere ruimte wellicht een hittebron. Hennepplantjes moeten veel warmte krijgen, en speciale warmtelampen die hiervoor gebruikt worden kunnen deze hittebron wel eens zijn.";
        }
    }
}
