using UnityEngine;
using UnityEngine.UI;

public class SaveHighScore : MonoBehaviour {

    public string playerName;
    public InputField input; 
    
    public void Save()
    {
        //Debug.Log("Save");
        int insertLocation = -1;
        for (int i = 0; i < 11; i++)
        {
            if (PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("Score" + i.ToString()))
            {
                insertLocation = i;
                break;
            }
        }
        if (insertLocation >= 0)
        {
            InsertNewScore(insertLocation);
            input.text = "";
         //   Debug.Log("Saved Game!");
        }
    }

    public void InsertNewScore(int insertLocation)
    {
        for(int i = 10; i > insertLocation; i--)
        {
            PlayerPrefs.SetString("Name" + i, PlayerPrefs.GetString("Name" + (i - 1)));
            PlayerPrefs.SetInt("Score" + i, PlayerPrefs.GetInt("Score" + (i - 1)));
            PlayerPrefs.SetInt("Gold" + i, PlayerPrefs.GetInt("Gold" + (i - 1)));
            PlayerPrefs.SetInt("Wave" + i, PlayerPrefs.GetInt("Wave" + (i - 1)));
        }
        name = input.text;
        PlayerPrefs.SetString("Name" + insertLocation.ToString(), name);
        PlayerPrefs.SetInt("Gold" + insertLocation.ToString(), PlayerPrefs.GetInt("CurrentGold"));
        PlayerPrefs.SetInt("Score" + insertLocation.ToString(), PlayerPrefs.GetInt("CurrentScore"));
        PlayerPrefs.SetInt("Wave" + insertLocation.ToString(), PlayerPrefs.GetInt("CurrentWave"));
    }
    
}
