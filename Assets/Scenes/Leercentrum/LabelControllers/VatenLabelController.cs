using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VatenLabelController : MonoBehaviour {
    public Text descriptionText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonVaten"))
        {
            descriptionText.text = "Iedereen heeft thuis wel azijn staan, chemicaliën als mierenzuur zijn echter wat zeldzamer om in huis te hebben liggen. Ook spullen als vaten en kolven worden in een standaard huishouden niet vaak gebruikt.";
        }
    }
}
