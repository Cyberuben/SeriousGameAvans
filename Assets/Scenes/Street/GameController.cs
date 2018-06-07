using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameObject> prefabs;
    public GameObject sidewalk;

    private int _houseCount;
    private List<GameObject> _houses;
    private float _streetWidth = 0.0f;
	void Start () {
        _houseCount = Mathf.FloorToInt(Random.Range(15, 25));

        for (int i = 0; i < _houseCount; i++)
        {
            int houseIndex = Mathf.FloorToInt(Random.Range(0, prefabs.Count - 0.01f));
            GameObject house = Instantiate(prefabs[houseIndex], Vector3.zero, Quaternion.identity);
            float width = house.GetComponent<Collider>().bounds.size.x;
            house.transform.position = new Vector3(_streetWidth + (width / 2.0f), 0, 0);
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
		
	}
}
