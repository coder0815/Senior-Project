using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    private string NameofPlayer;
    public Text LoadSavedUsername;
    public InputField InputFieldText;
    public Button SavedInfo;
    

	// Use this for initialization
	void Start ()
    {
        LoadSavedUsername.text = "Save Name";
        InputFieldText.text = PlayerPrefs.GetString("Playersname");
        //LoadSavedUsername.text = PlayerPrefs.GetString("Playersname");
        SavedInfo.onClick.AddListener(checkUsername);

	}

    public void checkUsername()
    {

        NameofPlayer = InputFieldText.text;
        PlayerPrefs.SetString("Playersname", NameofPlayer);
        LoadSavedUsername.text = "Name Saved";
    }

    // Update is called once per frame
    void Update () {

    }
}
