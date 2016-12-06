using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ShowOptionsScreen : MonoBehaviour {

    public Button optionsButton;

	// Use this for initialization
	void Start () {

        optionsButton = gameObject.GetComponent<Button>();
        optionsButton.onClick.AddListener(ShowOptions);
	}

    private void ShowOptions()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
