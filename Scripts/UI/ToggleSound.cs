using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour {


    public Button soundToggle;
    public Text soundToggleText;
	// Use this for initialization
	void Start () {

        if (GameController.GetSoundStatus())
        {
            soundToggleText.text = "Sound: Off";
        }
        else if (!GameController.GetSoundStatus())
        {
            soundToggleText.text = "Sound: On";
        }
        soundToggle = gameObject.GetComponent<Button>();
        soundToggle.onClick.AddListener(ToggleTheSound);
        
	}

    public void ToggleTheSound()
    {
        // toggle the words on the sound toggle button
        if (soundToggleText.text == "Sound: On")
        {
            soundToggleText.text = "Sound: Off";
            if (!GameController.GetSoundStatus())
            {
                GameController.SwitchSoundStatus();
            }
        }
        else if (soundToggleText.text == "Sound: Off")
        {
            soundToggleText.text = "Sound: On";
            if (GameController.GetSoundStatus())
            {
                GameController.SwitchSoundStatus();
            }
        }
        // will need to add code to switch sound off here


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
