using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject leaderboardButton;
    public GameObject learningCenterButton;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera camera = Camera.main;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                string target = hit.collider.gameObject.name;
                Menu menu = camera.GetComponent<Menu>();
                for (int i = 0; i < menu.screens.Count; i++)
                {
                    if (menu.screens[i].gameObject.name.Equals(target))
                    {
                        menu.MoveTo(i);
                        break;
                    }
                }
            }
        }
    }
}
