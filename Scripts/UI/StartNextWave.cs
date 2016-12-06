using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class StartNextWave : MonoBehaviour {


    private GameController gameController;
    private Spawn spawn;
    private CursorMode mode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public Button button;

	// Use this for initialization
	void Start () {

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawn = GameObject.FindGameObjectWithTag("Spawn Point").GetComponent<Spawn>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(StartWave);
	
	}

    private void StartWave()
    {
        // if game is on the right wave
        if (gameController.GetDifferenceBetweenWaves() != 1)
        {
            gameController.IncrementWave();
        }
       
        spawn.ResetSpawnTime();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
