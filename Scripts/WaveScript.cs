using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour {


    int waveNumber = 1;
    int enemiesEachWave = 10;
	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Text>().text = "Wave " + waveNumber;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncreaseWaveNumber()
    {
        waveNumber++;
    }

    public int GetEnemiesPerWave()
    {
        return enemiesEachWave;
    }

    public void SetNumberEnemiesPerWave(int number)
    {
        enemiesEachWave = number;
    }
}
