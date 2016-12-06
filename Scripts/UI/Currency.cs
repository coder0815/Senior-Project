using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

    //Player current gold amount.
    public int playerCurrency;

    void Start()
    {
        playerCurrency = 300;
        gameObject.GetComponent<Text>().text = "Gold " + playerCurrency;
        GameController.gameController.gold = playerCurrency;
    }

    public void IncreaseCurrency(int amount)
    {
        playerCurrency += amount;
        GameController.gameController.gold = playerCurrency;
    }

    public void DecreaseCurrency(int amount)
    {
        playerCurrency -= amount;
        GameController.gameController.gold = playerCurrency;
    }
    public void DisplayCurrency()
    {
        gameObject.GetComponent<Text>().text = "Gold " + playerCurrency;
    }

    public int GetCurrency()
    {
        return playerCurrency;
    }

    

	
}
