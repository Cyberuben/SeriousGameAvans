using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {
    public string name;
    public GameObject house;

    private IndicatorController _indicatorController;

	void Start () {
        _indicatorController = house.GetComponent<IndicatorController>();
	}

    private void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _indicatorController.Found(name);
        }
    }
}
