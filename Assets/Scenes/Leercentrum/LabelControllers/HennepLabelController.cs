using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HennepLabelController : MonoBehaviour {

    public Text descriptionText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (GameObject.Find("AchievmentButtonHennep"))
        {
            descriptionText.text = "Anijsgeur. Bij de productie van synthetische drugs worden chemicaliën gebruikt.Door deze chemicaliën ruikt een drugslab sterk naar anijs.";
        }
    }
}
