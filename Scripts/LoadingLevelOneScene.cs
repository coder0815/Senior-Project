using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevelOneScene : MonoBehaviour {

    private Slider slider;

    // operation for loading bar
    AsyncOperation loadingOperation;

	// Use this for initialization
	void Start () {

        slider = GetComponent<Slider>();

        loadingOperation = SceneManager.LoadSceneAsync("Level One");
       
	
	}
	
	// Update is called once per frame
	void Update () {

        // if the operation has not finished loading
        // the scene is still loading so update the progress bar
       if (!loadingOperation.isDone)
        {
            slider.value = loadingOperation.progress;
        }

        //slider.value = SceneManager.LoadSceneAsync("Level One").progress;
        //Debug.Log(SceneManager.LoadSceneAsync("Level One").progress);
	
	}
}
