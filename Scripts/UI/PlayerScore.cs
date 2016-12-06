using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    //Player current score.
    int playerScore = 0;

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
        GameController.gameController.score = playerScore;
    }

    public void DisplayScore()
    {
        gameObject.GetComponent<Text>().text = "Score: " + playerScore;
    }

}
