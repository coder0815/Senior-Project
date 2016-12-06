using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ShowCreditsScreen : MonoBehaviour {


    public Button showCreditsButton;
	// Use this for initialization
	void Start () {

        showCreditsButton.onClick.AddListener(ShowCredits);
	}

    private void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
