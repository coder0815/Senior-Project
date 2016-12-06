using UnityEngine;
using System.Collections;


public class SoundOnOff : MonoBehaviour {


    private AudioSource music;
	// Use this for initialization
	void Start () {

        music = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameController.GetSoundStatus())
        {
            music.enabled = false;
            
        }
        else if (!GameController.GetSoundStatus())
        {
            music.enabled = true;
        }
	
	}
}
