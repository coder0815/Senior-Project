using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DamageDetection : MonoBehaviour {

	public Slider healthSlider;
	public GameObject lowHealthWarning;
	public int maxHealth = 100;
	public int currentHealth;

	// Use this for initialization
	void Start () {

		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
        Debug.Log(other + "hit the castle.");
		if (other.tag == "Enemy")
		{
            GameController.gameController.numEnemiesRemaining--;
			Destroy(other);
			DealDamage();
			
		}

	}

	private void DealDamage()
	{
		currentHealth -= 10;
		GameObject.FindGameObjectWithTag("Health").GetComponent<Slider>().value = currentHealth;
	   if (currentHealth <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
        PlayerPrefs.SetInt("CurrentWave", GameController.gameController.currentWave);
        PlayerPrefs.SetInt("CurrentScore", GameController.gameController.score);
        PlayerPrefs.SetInt("CurrentGold", GameController.gameController.gold);
		SceneManager.LoadScene("GameOverScene");
	}
}
