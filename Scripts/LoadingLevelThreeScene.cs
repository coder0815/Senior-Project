using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevelThreeScene : MonoBehaviour {


    private Slider slider;

    AsyncOperation loadingOperation;
	// Use this for initialization
	void Start () {

        slider = GameObject.Find("Slider").GetComponent<Slider>();
        loadingOperation = SceneManager.LoadSceneAsync("Level Three");
	}
	
	// Update is called once per frame
	void Update () {
	
        if (!loadingOperation.isDone)
        {
            slider.value = loadingOperation.progress;
        }
	}
}
