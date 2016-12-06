using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CloseMenu : MonoBehaviour {

    public Button close;
    public Canvas menu;

	// Use this for initialization
	void Start () {

        
        close.onClick.AddListener(CloseTheMenu);
	
	}

    private void CloseTheMenu()
    {
        menu.enabled = false;
        GameController.ResetBuildSite();
        GameController.towerSelected = null;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
