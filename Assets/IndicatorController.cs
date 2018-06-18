using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour {
    public int houseIndex;
    public List<IndicatorEntry> indicators;
    public GameObject snow;

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
        if (!GameController.Instance.houses[houseIndex].indicatorFound)
        {
            GameController.Instance.houses[houseIndex].indicatorFound = true;
            GameController.Instance.AddScore(100);
            GameController.Instance.IndicatorsFound++;
        }
    }
}
