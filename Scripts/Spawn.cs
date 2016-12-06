using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    public float spawnRate;
    public float timer;
    public float timeBetweenWavesMax;
    public float timeBetweenWavesCurrent = 30.0f;
    public int enemiesToSpawn;
    public GameObject[] enemyPrefabs;
    public GameObject spawnLocation;
    public Pathing spawnPath;

    public GameController game;
    public GameObject nextWaveTimer;
    private bool waveForcedToStart = false;

    public List<Wave> waves;

	// Use this for initialization
	void Start () {
        enemiesToSpawn = waves[0].waveEnemies.Count;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnRate && timeBetweenWavesCurrent <= 0)
        {
            timer = 0f;
            game.numEnemiesRemaining++;
            GameObject newEnemy = Instantiate(enemyPrefabs[waves[game.currentWave-1].waveEnemies[game.spawnedEnemies]], spawnLocation.transform.position, spawnLocation.transform.localRotation, transform) as GameObject;
            
            newEnemy.GetComponent<MoveTowardsPathNode>().SetPathToFollow(spawnPath);
            game.spawnedEnemies++;
            // 10 enemies, lets increment the wave counter
            if (game.spawnedEnemies % enemiesToSpawn == 0 && waveForcedToStart == false)
            {
                GameObject[] deathParticles = GameObject.FindGameObjectsWithTag("DeathParticle");
                foreach (GameObject part in deathParticles)
                {
                    Destroy(part);
                }
                game.IncrementWave();
                timeBetweenWavesCurrent = timeBetweenWavesMax;
                if (game.currentWave <= 25)
                    enemiesToSpawn = waves[game.currentWave - 1].waveEnemies.Count;
                else
                {
                    enemiesToSpawn += 2;
                    spawnRate -= .02f;
                }
                if (spawnRate > 0.5f)
                    spawnRate -= 0.1f;
                // 5 waves, lets  open a door
                if (game.currentWave % 5 == 0 && game.currentWave > 0)
                    game.OpenDoor();
            }
            
        }
        else if (timeBetweenWavesCurrent > 0 && game.numEnemiesRemaining ==0)
        {
            timeBetweenWavesCurrent -= Time.deltaTime;
            nextWaveTimer.GetComponent<Text>().text = "Next Wave: " + (int)timeBetweenWavesCurrent;
        }
        else
        {
            nextWaveTimer.GetComponent<Text>().text = "Next Wave: 0";
        }

        waveForcedToStart = false;
         
	    
	}

    public void ResetSpawnTime()
    {
        
        timeBetweenWavesCurrent = 0.0f;
        nextWaveTimer.GetComponent<Text>().text = "Next Wave: 0";
       waveForcedToStart = true;
        
    }
}
