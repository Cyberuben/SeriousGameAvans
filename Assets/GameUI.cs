using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public Text score;
    public Text time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int timeLeft = GameController.Instance.TimeLeft();
        int seconds = timeLeft % 60;
        int minutes = Mathf.FloorToInt(timeLeft / 60);

        time.text = string.Format("{0}:{1}", minutes.ToString("D2"), seconds.ToString("D2"));

        score.text = GameController.Instance.Score().ToString("n0");
	}
}
