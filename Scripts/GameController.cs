using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController gameController;

    public int currentWave = 1;
    public int previousWave = 0;
    public int spawnedEnemies = 0;
    public int spawnedEnemiesTotal = 0;
    public int numDoorsOpen = 0;
    public int gold;
    public int score;

    public int numEnemiesRemaining = 0;

    // current tower selected
    public static GameObject towerSelected;

    public static GameObject selectedBuildSite;


    // control turning sound on and off
    // default == sound on
    private static bool isSoundOff = false;


    public List<GameObject> doors;
    public List<Pathing> allPaths;
    public List<int> doorIndexes;

    public GameObject waveText;
    
    void Awake()
    {
        gameController = this;
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject.Find("In_Game_Menu").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
        }

    }
    public void IncrementWave()
    {
        if (currentWave == 0)
        {
           
            currentWave++;
            spawnedEnemiesTotal += spawnedEnemies;
            spawnedEnemies = 0;
            waveText.GetComponent<Text>().text = "Wave: " + currentWave;
        }
        else
        {
            
            previousWave = currentWave;
            currentWave++;
            spawnedEnemiesTotal += spawnedEnemies;
            spawnedEnemies = 0;
            waveText.GetComponent<Text>().text = "Wave: " + currentWave;
        }

        
    }

    public void OpenDoor()
    {
        if (numDoorsOpen < doors.Count) // there is a door to open still
        {
            doors[numDoorsOpen].SetActive(false);
            allPaths[doorIndexes[numDoorsOpen]].doorOpen = true;
        }
        numDoorsOpen++;
    }

    public int GetDifferenceBetweenWaves()
    {
        return (currentWave - previousWave);
    }

    public void SetCurrentSelectedTower(GameObject tower)
    {
        GameController.towerSelected = tower;
        Debug.Log("Current Tower: " + towerSelected.name);
    }

    public void DestroySelectedTower()
    {
        Destroy(GameController.towerSelected);
    }

    public static void SwitchSoundStatus()
    {
        isSoundOff = !isSoundOff;
    }

    public static bool GetSoundStatus()
    {
        return isSoundOff;
    }

    public static void SetBuildSite(GameObject obj)
    {
        selectedBuildSite = obj;
    }

    public static GameObject GetBuildSite()
    {
        return selectedBuildSite;
    }

    public static void ResetBuildSite()
    {
        selectedBuildSite = null;
    }

    public void ResetWaveCount()
    {
        currentWave = 0;
        previousWave = 0;
    }
}

