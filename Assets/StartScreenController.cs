using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenController : MonoBehaviour
{
    public Text labelToEdit;
    private string startupText;
    private string continueText;
    private bool isTextDone;
    public Text labelForContinue;
    public Sprite nextImage;
    public Image nextImageLocation;

    private float textSpeed;
    private string nextTextParagraphOne;
    private string nextTextParagraphThree;
    private string nextTextParagraphTwo;
    public Text paragraphOne;
    public Text paragraphTwo;
    public Text paragraphThree;
    private AudioSource audio;
    private bool isSecondTextDone;

    // Use this for initialization
    void Start()
    {
        startupText = "WAAR ONDER- EN BOVENWERELD ELKAAR ONTMOETEN";
        nextTextParagraphOne = "IN NEDERLAND ZIJN IN 2017 IN TOTAAL 4670 HENNEPKWEKERIJEN ONTMANTELD, DIT KOMT NEER OP 13 KWEKERIJEN PER DAG!";
        nextTextParagraphTwo = "ALLEEN AL IN TILBURG BEDRAAGT DE OMZET VAN DEZE HENNEPPRODUCTIE 900 MILJOEN EURO.";
        nextTextParagraphThree = "11 MILJARD LEKT PER JAAR WEG AAN FRAUDE, DAT IS MEER DAN DE HELE BEGROTING VAN DE VEILIGHEID VAN JUSTITIE.";
        isTextDone = false;
        isSecondTextDone = false;
        audio = GetComponent<AudioSource>();
        StartCoroutine(DrawText());
        textSpeed = 0.001f;
    }

    IEnumerator DrawText()
    {
        for (int i = 0; i < startupText.Length; i++)
        {
            labelToEdit.text += startupText[i];

            audio.Play();
            yield return new WaitForSeconds(0.05f);
        }
        isTextDone = true;
        labelForContinue.text = "Druk op een toets om door te gaan";
    }

    IEnumerator OpenStart()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }

    IEnumerator OpenNextScene()
    {
        nextImageLocation.sprite = nextImage;
        ResetAllLabels();
        paragraphOne.enabled = true;

       
        for (int i = 0; i < nextTextParagraphOne.Length; i++)
        {
            paragraphOne.text += nextTextParagraphOne[i];
            audio.Play();
            yield return new WaitForSeconds(textSpeed);
        }

        isSecondTextDone = true;
        labelForContinue.text = "Druk op een toets om door te gaan";
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < nextTextParagraphTwo.Length; i++)
        {
            audio.Play();
            paragraphTwo.text += nextTextParagraphTwo[i];
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < nextTextParagraphThree.Length; i++)
        {
            audio.Play();
            paragraphThree.text += nextTextParagraphThree[i];
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void ResetAllLabels()
    {
        labelToEdit.text = "";
        labelForContinue.text = "";
    }

    void Update()
    {
        if (Input.anyKey && isTextDone)
        {
            StartCoroutine(OpenNextScene());
            isTextDone = false;
        }

        if (Input.anyKey && isSecondTextDone)
        {
            StartCoroutine(OpenStart());
        }
    }
}
