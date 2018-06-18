using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour {
    public int houseIndex;
    public List<IndicatorEntry> indicators;

    [System.Serializable]
    public class IndicatorEntry
    {
        public string name;
        public GameObject reference;
    }

    public void EnableIndicator(string name)
    {
        foreach (IndicatorEntry indicator in indicators)
        {
            if (indicator.name.Equals(name) && indicator.reference != null)
            {
                if (name.Equals("snow"))
                {
                    indicator.reference.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    indicator.reference.gameObject.SetActive(true);
                }
            }
        }
    }
	
	public void Found(string name)
    {
        GameController.Instance.FoundIndicator(houseIndex);
    }
}
