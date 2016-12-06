using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayGameButtonClick : MonoBehaviour {


    public CursorMode mode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Button button;
	// Use this for initialization
	void Start () {

        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(StartGame);
	}

    private void StartGame()
    {
        SceneManager.LoadScene("DifficultySelectionScreen");
    }

  
    
}
