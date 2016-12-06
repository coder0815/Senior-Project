using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowControls : MonoBehaviour {

    public GameObject controlPanel;
    
    public void ShowControlPanel()
    {
        controlPanel.SetActive(true);
    }

    public void HideControlPanel()
    {
        controlPanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainScreen");  
    }
}
