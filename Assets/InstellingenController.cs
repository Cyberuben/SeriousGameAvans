using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstellingenController : MonoBehaviour {
    public Toggle musicOn;
    public Button[] difficultyButtons;
    public GameObject[] CheckedImages;

	// Use this for initialization
	void Start ()
    {
        musicOn.onValueChanged.AddListener(delegate {
             ToggleValueChanged(musicOn);
         });

        musicOn.isOn = GameController.Instance.playAudio;

        DisableAllBtnsBesides(GameController.Instance.difficulty.ToString());
    }

    private void DisableAllBtnsBesides(string btnName)
    {
        for (int i = 0; i < CheckedImages.Length; i++)
        {
            if (!CheckedImages[i].name.ToLower().Contains(btnName.ToLower()))
            {
                CheckedImages[i].SetActive(false);
            }
            else
            {
                CheckedImages[i].SetActive(true);
            }
        }
    }

    public void EasyButtonPressed()
    {
        GameController.Instance.difficulty = GameController.Difficulty.EASY;
        DisableAllBtnsBesides("easy");
    }

    public void MediumButtonPressed()
    {
        GameController.Instance.difficulty = GameController.Difficulty.MEDIUM;
        DisableAllBtnsBesides("medium");
    }

    public void HardButtonPressed()
    {
        GameController.Instance.difficulty = GameController.Difficulty.HARD;
        DisableAllBtnsBesides("hard");

    }

    void ToggleValueChanged(Toggle change)
    {
        if (musicOn.isOn)
        {
            GameController.Instance.playAudio = true;
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
        }
        else
        {
            GameController.Instance.playAudio = false;
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StartCoroutine(GameController.Instance.BackToStart());
        }
    }
}
