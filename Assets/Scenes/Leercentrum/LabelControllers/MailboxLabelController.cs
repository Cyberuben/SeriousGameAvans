using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailboxLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementMailbox"))
        {
            descriptionText.text = "Brievenbussen puilen uit van de post. Óf de bewoner heeft een leuke vakantie, of hij gebruikt het pand voor andere doeleinden dan er simpelweg wonen.";
        }
    }
}
