using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {


    public int damage = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Enemy")
        {
           other.GetComponent<EnemyHealth>().TakeDamage(damage);

        }
        

        
       

    }
}
