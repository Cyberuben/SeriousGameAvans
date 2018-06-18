using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonCamera"))
        {
            descriptionText.text = "Deze bewoners houden een oogje in het zeil. Verwachten ze ongewenst bezoek? Dit kan duiden op illegale praktijken.";
        }
    }
}
