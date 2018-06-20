using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadlockLabelController : MonoBehaviour
{
    public Text descriptionText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (GameObject.Find("AchievementButtonHangslot"))
        {
            descriptionText.text = "Waarom zit er een hangslot op deze deur? Wat wordt er achter deze deur verborgen gehouden?";
        }
    }
}
