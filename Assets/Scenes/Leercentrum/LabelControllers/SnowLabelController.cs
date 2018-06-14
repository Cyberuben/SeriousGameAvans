using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowLabelController : MonoBehaviour {
    public Text descriptionText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonSnow"))
        {
            descriptionText.text = "Zijn de bewoners extreme koukleumen? Wellicht, maar het kan ook dat de warmte die nodig is voor een hennepkwekerij op zolder de sneeuw snel doet smelten.";
        }
    }
}
