using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {


    public int maxHealth = 100;
    private int currentHealth;
    public int gold;
    public int score;

    public PlayerScore playerScore;
    public Currency playerGold;

    public GameObject DeathParticle;
    public GameObject ParticleParent;
    private Slider enemyHealthSlider;

	// Use this for initialization
	void Start ()
    {
        playerScore = GameObject.FindGameObjectWithTag("Score").GetComponent<PlayerScore>();
        playerGold = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        enemyHealthSlider = gameObject.GetComponentInChildren<Slider>();
        currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
           
            EnemyDeath();
        }
    }

//	void OnTriggerEnter (Collider other) {
//		if (other.gameObject.tag.Equals("Arrow")) {
//			Destroy (this.gameObject);
//		}
//	}

    private void EnemyDeath()
    {
        GameController.gameController.numEnemiesRemaining--;
        playerScore.IncreaseScore(score);
        playerScore.DisplayScore();
        playerGold.IncreaseCurrency(gold);
        playerGold.DisplayCurrency();
        Vector3 temp = transform.position;
        temp.y += 1;
        Instantiate(DeathParticle, transform.position, transform.rotation);        
        Destroy(this.gameObject);
    }
}
