using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    public List<Material> atticCeilingMaterials;
    public List<Material> atticWallMaterials;
    public List<Material> atticFloorMaterials;

    public List<Material> groundFloorCeilingMaterials;
    public List<Material> groundFloorWallMaterials;
    public List<Material> groundFloorFloorMaterials;

    public List<Material> basementCeilingMaterials;
    public List<Material> basementWallMaterials;
    public List<Material> basementFloorMaterials;

    public List<Material> selectedMaterials;

    // Use this for initialization
    void Start () {
        selectedMaterials = new List<Material>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
