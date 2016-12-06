using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ShowMainMenu : MonoBehaviour
{

    public Button MainMenu;
    public GameObject gameController;


    // Use this for initialization
    void Start()
    {

        
        MainMenu.onClick.AddListener(MainMenuScreen);
    }

    private void MainMenuScreen()
    {
        if (gameController != null)
        {
            gameController.GetComponent<GameController>().ResetWaveCount();
        }
        
        SceneManager.LoadScene("MainScreen");
    }
}