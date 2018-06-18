using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildingInside : MonoBehaviour {
    public List<GameObject> floors;
    public int currentFloor;
    public Button up;
    public Button down;
    public Button back;

    private int _index;
    private IndicatorController _controller;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<IndicatorController>();

        _index = GameController.Instance.enteredHouse;
        _controller.houseIndex = _index;

        Camera camera = Camera.main;
        float height = camera.orthographicSize * 2;
        float width = height * camera.aspect;

		for(int i = 0; i < floors.Count; i++)
        {
            floors[i].transform.position = new Vector3(0, i * height, 0);
            float floorWidth = floors[i].GetComponent<BoxCollider>().size.x;

            float scale = 1.0f;
            if (floorWidth > width * 0.8f)
            {
                scale = ((width * 0.8f) / floorWidth);
            }

            floors[i].transform.localScale = new Vector3(scale, scale, 1);
        }

        ChangeFloors(0);

        if (_index != -1)
        {
            if (GameController.Instance.houses != null && GameController.Instance.houses[_index].indicator != null)
            {
                _controller.EnableIndicator(GameController.Instance.houses[_index].indicator);
            }
        }

        up.onClick.AddListener(delegate { ChangeFloors(-1); });
        down.onClick.AddListener(delegate { ChangeFloors(1); });
        back.onClick.AddListener(delegate {
            GameController.Instance.enteredHouse = -1;
            SceneManager.LoadScene("Street");
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeFloors(int direction)
    {
        currentFloor += direction;
        if (currentFloor < 0)
        {
            currentFloor = 0;
        }

        if (currentFloor > floors.Count - 1)
        {
            currentFloor = floors.Count - 1;
        }

        if (currentFloor > 0)
        {
            up.gameObject.SetActive(true);
        } else
        {
            up.gameObject.SetActive(false);
        }

        if (currentFloor < floors.Count - 1)
        {
            down.gameObject.SetActive(true);
        }
        else
        {
            down.gameObject.SetActive(false);
        }

        Camera.main.transform.position = new Vector3(0, floors[currentFloor].transform.position.y, -10);
    }
}
