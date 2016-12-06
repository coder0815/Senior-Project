using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    public Material[] materials = new Material[2];

    public float flashInterval = 0.33f;

    public Renderer rend;
    private bool flash;

    public int waveToOpen;



	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (waveToOpen - GameController.gameController.currentWave <= 2 && waveToOpen - GameController.gameController.currentWave > 0)
            flash = true;
        else
        {
            flash = false;
            rend.sharedMaterial = materials[0];
        }

        if (flash)
        {
            int index = Mathf.FloorToInt(Time.time / flashInterval);
            index = index % 2;
            rend.sharedMaterial = materials[index];
        }
	}


}
