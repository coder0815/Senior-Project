using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SlowEnemy : MonoBehaviour {



    private MoveTowardsPathNode enemyMove;
    
	// Use this for initialization
	void Start () {

        
	}

    

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyMove = other.GetComponent<MoveTowardsPathNode>();
            enemyMove.ReduceSpeed();

            
        }
    }
}
