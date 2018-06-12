using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenController : MonoBehaviour
{

    public Text labelToEdit;
    private string startupText;

    // Use this for initialization
    void Start()
    {
        startupText = "WAAR ONDER- EN BOVENWERELD ELKAAR ONTMOETEN";
        StartCoroutine(DrawText());
    }

    IEnumerator DrawText()
    {
        for (int i = 0; i < startupText.Length; i++)
        {
            labelToEdit.text += startupText[i];
            yield return new WaitForSeconds(0.08f);
        }
    }
}
