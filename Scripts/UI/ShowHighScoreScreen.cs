using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ShowHighScoreScreen : MonoBehaviour {

	private Button highScoreButton;


	// Use this for initialization
	void Start () {

		highScoreButton = gameObject.GetComponent<Button>();
		highScoreButton.onClick.AddListener(LoadHighScoreScreen);
	}

	private void LoadHighScoreScreen()
	{
		SceneManager.LoadScene("HighScoreScreen");
	}
}
