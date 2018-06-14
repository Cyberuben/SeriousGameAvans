using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {
    public Text score;
    public Text time;
    public Text indicators;
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button menuButton;

    public Button pauseButton;

	// Use this for initialization
	void Start () {
        pauseButton.onClick.AddListener(delegate
        {
            GameController.Instance.PauseGame();
            pauseMenu.SetActive(true);
        });

        resumeButton.onClick.AddListener(delegate
        {
            GameController.Instance.ResumeGame();
            pauseMenu.SetActive(false);
        });

        menuButton.onClick.AddListener(delegate
        {
            GameController.Instance.gameState = GameController.GameState.MENU;
            SceneManager.LoadScene("Menu");
        });
	}
	
	// Update is called once per frame
	void Update () {
        int timeLeft = GameController.Instance.TimeLeft;
        int seconds = timeLeft % 60;
        int minutes = Mathf.FloorToInt(timeLeft / 60);

        time.text = string.Format("{0}:{1}", minutes.ToString("D1"), seconds.ToString("D2"));

        indicators.text = string.Format("{0}/{1}", GameController.Instance.IndicatorsFound, GameController.Instance.IndicatorsTotal);

        score.text = GameController.Instance.Score.ToString("n0");
	}
}
