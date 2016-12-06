using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StartNewGameScript : MonoBehaviour {


    // need a button to activate the scene transition onClick()

    public Button button;
    
	// Use this for initialization
	void Start () {

        button.onClick.AddListener(NavigateScenes);
	}

    private void NavigateScenes()
    {
       
        if (button.name == "EasyButton")
        {
            // This is going to change but for now just load the level one screen.
            

            SceneManager.LoadScene("Level One Loading Screen");
            

        }
        else if (button.name == "MediumButton")
        {
            SceneManager.LoadScene("Level Two Loading Screen");
          
        }
        else if (button.name == "HardButton")
        {
            SceneManager.LoadScene("Level Three Loading Screen");
            

        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
