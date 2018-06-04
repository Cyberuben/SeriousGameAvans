using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    public List<Material> ceilingMaterials;
    public List<Material> wallMaterials;
    public List<Material> floorMaterials;

    public List<GameObject> ceiling;
    public List<GameObject> walls;
    public List<GameObject> floor;

	// Use this for initialization
	void Start () {
	    if (ceilingMaterials != null && ceiling != null)
        {
            int random = Mathf.FloorToInt(Random.Range(0, ceilingMaterials.Count - 0.01f));
            ceiling.ForEach(ceiling =>
            {
                ceiling.GetComponent<Renderer>().material = ceilingMaterials[random];
            });
        }

        if (wallMaterials != null && walls != null)
        {
            int random = Mathf.FloorToInt(Random.Range(0, walls.Count - 0.01f));
            walls.ForEach(wall =>
            {
                wall.GetComponent<Renderer>().material = wallMaterials[random];
            });
        }

        if (floorMaterials != null && floor != null)
        {
            int random = Mathf.FloorToInt(Random.Range(0, floorMaterials.Count - 0.01f));
            floor.ForEach(_floor =>
            {
                _floor.GetComponent<Renderer>().material = floorMaterials[random];
            });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
