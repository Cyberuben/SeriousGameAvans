using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour {
    public GameObject sidewalk;
    public GameObject gameControllerConfig;

    private GameControllerConfig _config;
    private List<GameObject> _houses;
    private float _streetWidth = 0.0f;
    private Vector3 _dragStart;
    private Vector3 _cameraStart;

	void Start () {
        if (GameController.Instance.gameState == GameController.GameState.MENU)
        {
            GameController.Instance.StartGame();
        }

        _houses = new List<GameObject>();

        if (GameController.Instance.cameraPosition == Vector3.zero)
        {
            Camera camera = Camera.main;
            float screenHeight = 2f * camera.orthographicSize;
            float screenWidth = screenHeight * camera.aspect;
            float screenWidthHalf = screenWidth / 2.0f;

            this.transform.position = new Vector3(-5.0f + screenWidthHalf, camera.orthographicSize - 0.25f, -10.0f);
            GameController.Instance.cameraPosition = this.transform.position;
        }
        else
        {
            this.transform.position = GameController.Instance.cameraPosition;
        }

        for (int i = 0; i < GameController.Instance.houses.Count; i++)
        {
            GameObject house = Instantiate(GameController.Instance.houses[i].prefab, Vector3.zero, Quaternion.identity);
            _houses.Add(house);
            float width = house.GetComponent<Collider>().bounds.size.x;
            house.transform.position = new Vector3(_streetWidth + (width / 2.0f), 0, 0);
            IndicatorController indicatorController = house.GetComponent<IndicatorController>();
            indicatorController.houseIndex = i;
            if (GameController.Instance.houses[i].indicator != null)
            {
                indicatorController.EnableIndicator(GameController.Instance.houses[i].indicator);
            }
            _streetWidth += width;
        }

        float sidewalkWidth = -5;
        while (sidewalkWidth <= _streetWidth + 5)
        {
            Instantiate(sidewalk, new Vector3(sidewalkWidth, -0.125f, -2.0f), Quaternion.identity);
            sidewalkWidth += 10;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.IsPaused())
        {
            return;
        }

		if (Input.GetMouseButtonDown(0))
        {
            _dragStart = Input.mousePosition;
            _cameraStart = this.transform.position;
            return;
        }

        if (!Input.GetMouseButton(0))
        {
            return;
        }

        Camera camera = Camera.main;
        float screenHeight = 2f * camera.orthographicSize;
        float screenWidth = screenHeight * camera.aspect;
        float screenWidthHalf = screenWidth / 2.0f;

        float movePercentage = (Input.mousePosition.x - _dragStart.x) / Camera.main.scaledPixelWidth;

        this.transform.position = _cameraStart - new Vector3(movePercentage * screenWidth, 0, 0);

        if (this.transform.position.x < -5.0f + screenWidthHalf)
        {
            this.transform.position = new Vector3(-5.0f + screenWidthHalf, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x > _streetWidth + 5.0f - screenWidthHalf)
        {
            this.transform.position = new Vector3(_streetWidth + 5.0f - screenWidthHalf, this.transform.position.y, this.transform.position.z);
        }

        GameController.Instance.cameraPosition = this.transform.position;
	}
}
