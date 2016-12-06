using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayUpgradeMenu : MonoBehaviour {

    
    public Canvas upgradeInterface;
    private GameObject [] buildSite;
    
	// Use this for initialization
	void Start () {
        upgradeInterface = GameObject.Find("Tower Upgrade Menu").GetComponent<Canvas>();
        buildSite = GameObject.FindGameObjectsWithTag("Build Site");
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

    void OnMouseDown()
    {
        Time.timeScale = 0.0f;
        GameController.towerSelected = gameObject;
        
        foreach (GameObject site in buildSite)
        {
            if (gameObject.transform.position == site.transform.position)
            {
                GameController.SetBuildSite(site);
            }
        }
        upgradeInterface.enabled = true;
        

        
    }

}
