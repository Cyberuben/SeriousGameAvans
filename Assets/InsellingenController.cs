using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstellingenController : MonoBehaviour {
    public Toggle musicOn;

	// Use this for initialization
	void Start ()
    {
        musicOn.onValueChanged.AddListener(delegate {
             ToggleValueChanged(musicOn);
         });

        //musicOn.isOn = GameController.Instance.playAudio;
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
