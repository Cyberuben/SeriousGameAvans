using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallLabelController : MonoBehaviour
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
        if (GameObject.Find("AchievementWall"))
        {
            descriptionText.text = "Valse ruimtes. Afwijkingen in bouwtekeningen kunnen wijzen op valse ruimtes die gebruikt worden voor andere doeleinden dan wonen of werken. Let er goed op of de afmetingen op de tekening overeenkomen met de werkelijkheid.";
        }
    }
}
