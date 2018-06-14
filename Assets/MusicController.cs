using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        if (GameController.Instance.playAudio)
        {
            GetComponent<AudioSource>().Play();
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
