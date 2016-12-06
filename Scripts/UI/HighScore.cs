using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public GameObject[] hsGameObjects;
   
    void Awake()
    {
        //for (int i = 0; i < 11; i++)
        //{
        //    if (PlayerPrefs.HasKey("Name" + i))
        //    {
        //        if ((PlayerPrefs.GetString("Name") + i).Contains("Nobody"))
        //            continue;
        //    }
        //    name = "Nobody";
        //    PlayerPrefs.SetString("Name" + i, name);
        //    PlayerPrefs.SetInt("Gold" + i, 0);
        //    PlayerPrefs.SetInt("Score" + i, 0);
        //    PlayerPrefs.SetInt("Wave" + i, 0);
        //}
        Load();

    }

    public void Load()
    {
        for(int i = 0; i < hsGameObjects.Length; i++)
        {
            Text[] temp = hsGameObjects[i].GetComponentsInChildren<Text>();
            temp[1].text = PlayerPrefs.GetString("Name" + i);
            temp[2].text = PlayerPrefs.GetInt("Score" + i).ToString();
            temp[3].text = PlayerPrefs.GetInt("Wave" + i).ToString();
            temp[4].text = PlayerPrefs.GetInt("Gold" + i).ToString();
            if (temp[1].text.Equals(""))
                temp[1].text = "Nobody";
        }
    }
   
}
