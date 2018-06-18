using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public IndicatorController controller;
    public string scene;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameController.Instance.enteredHouse = controller.houseIndex;
            SceneManager.LoadScene(scene);
        }
    }
}
