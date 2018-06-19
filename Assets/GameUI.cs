﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {
    public Text score;
    public Text time;
    public Text indicators;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public InputField highscoreName;
    public Text gameOverHeader;
    public Text gameOverText;

    public GameObject indicatorInfo;
    public Text indicatorTitle;
    public Text indicatorDescription;
    public Image indicatorImage;

    public List<IndicatorInfo> indicatorDefinitions;

    [System.Serializable]
    public class IndicatorInfo
    {
        public string key;
        public string title;
        public string description;
        public Sprite image; 
    }

    private bool _scoreSubmitted = false;

    public void PauseGame()
    {
        GameController.Instance.PauseGame();
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        GameController.Instance.ResumeGame();
        pauseMenu.SetActive(false);
    }

    public void ReturnToMenu()
    {
        GameController.Instance.gameState = GameController.GameState.MENU;
        _scoreSubmitted = false;
        SceneManager.LoadScene("Menu");
    }

    public void SubmitHighscore()
    {
        Debug.Log(GameController.Instance.Score);
        Debug.Log(GameController.Instance.difficulty);
        Debug.Log(GameController.Instance.TimeLeft);
        Debug.Log(highscoreName.text);
    }
	
	// Update is called once per frame
	void Update () {
        int timeLeft = GameController.Instance.TimeLeft;
        int seconds = timeLeft % 60;
        int minutes = Mathf.FloorToInt(timeLeft / 60);

        time.text = string.Format("{0}:{1}", minutes.ToString("D1"), seconds.ToString("D2"));

        indicators.text = string.Format("{0}/{1}", GameController.Instance.IndicatorsFound, GameController.Instance.IndicatorsTotal);

        score.text = GameController.Instance.Score.ToString("n0");

        if (GameController.Instance.gameState == GameController.GameState.ENDED)
        {
            if (GameController.Instance.IndicatorsFound == GameController.Instance.IndicatorsTotal)
            {
                gameOverHeader.text = "Je hebt alle indicatoren gevonden!";
            }
            else
            {
                gameOverHeader.text = string.Format("Je hebt maar {0} van de {1} indicatoren gevonden...", GameController.Instance.IndicatorsFound, GameController.Instance.IndicatorsTotal);
            }

            gameOverText.text = string.Format("Je hebt hiermee {0} punten behaald. Voer hier onder je naam in voor het scoreboard!", GameController.Instance.Score.ToString("n0"));

            gameOverMenu.SetActive(true);
        }
	}

    public void ShowIndicatorInfo(string name)
    {
        indicatorTitle.text = "Onbekend";
        indicatorDescription.text = "Onbekend";
        indicatorImage.sprite = null;

        for (int i = 0; i < indicatorDefinitions.Count; i++) {
            if (indicatorDefinitions[i].key.Equals(name))
            {
                indicatorTitle.text = indicatorDefinitions[i].title;
                indicatorDescription.text = indicatorDefinitions[i].description;
                indicatorImage.sprite = indicatorDefinitions[i].image;
                indicatorImage.preserveAspect = true;
                break;
            }
        }

        indicatorInfo.SetActive(true);
    }

    public void HideIndicatorInfo()
    {
        indicatorInfo.SetActive(false);
    }
}
