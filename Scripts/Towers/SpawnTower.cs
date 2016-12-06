using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SpawnTower : MonoBehaviour
{

    /***************Objects*******************************/
    public GameObject tower;
    private Canvas buildMenu;
    private Canvas message;
    private BuildTower build;
    private GameObject spawnSite;
    private Text playerGoldText;
    private Change_Tower_Cursor mouseCursor;
    private Currency playerGold;

    //public bool isMessageDisplayed = false;
    //public float timeToDisplayMessage = 1.5f;
    //public float timeSinceMessageWasDisplayed = 0;

    public Button towerButton;
    

    /***************Properties*******************************/
    int currentPlayerGold = 0;
    int towerCost = 0;
    public string TowerCost { get; set; }
    bool isReady = false;
    Vector3 mousePos;


    // List of Tower costs

    int[] cost;
   



    // Use this for initialization
    void Start()
    {

        

        cost = new int[3];
        cost[0] = 100;
        cost[1] = 150;
        cost[2] = 200;
        mouseCursor = GetComponent<Change_Tower_Cursor>();
        playerGold = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        buildMenu = GameObject.Find("Tower Build Menu").GetComponent<Canvas>();
        message = GameObject.Find("Money Notification").GetComponent<Canvas>();
        TowerCost = gameObject.GetComponentInChildren<Text>().text;
        towerButton.onClick.AddListener(BuildTowerHere);
    }

    private void BuildTowerHere()
    {
        spawnSite = GameController.GetBuildSite();
        GameController.ResetBuildSite();
        
       
        foreach (int amount in cost)
        {
            if (amount.ToString() == TowerCost)
            {
                towerCost = amount;

                break;
            }
        }
        if (playerGold.GetCurrency() >= towerCost)
        {
            Instantiate(tower, spawnSite.transform.position, spawnSite.transform.rotation);
            UpdatePlayerGold(towerCost);
            spawnSite.GetComponent<BuildTower>().SwitchHasTower();
        }
        else
        {
            message.enabled = true;
            Invoke("DisableMessage", 2.5f);
        }
       
        
        buildMenu.enabled = false;
        spawnSite.GetComponent<BuildTower>().SwitchTowerBuildMenuState();
        
        Time.timeScale = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {


        //if (isMessageDisplayed)
        //{
        //    timeSinceMessageWasDisplayed += Time.deltaTime;
        //    if (timeSinceMessageWasDisplayed == timeToDisplayMessage)
        //    {
        //        timeSinceMessageWasDisplayed = 0;
        //        isMessageDisplayed = false;
        //        message.enabled = false;
        //    }
        //}

       
    }

    private void DisableMessage()
    {
        message.enabled = false;
    }

    private void UpdateCursor()
    {
        mouseCursor.ChangeCursorBack();
    }

    private void UpdatePlayerGold(int amount)
    {
        playerGold.DecreaseCurrency(amount);
        playerGold.DisplayCurrency();
    }



    // Set state of the tower to spawn to not ready to prevent multiple instantiations at once.
    public void ChangeReadyState()
    {
        isReady = !isReady;
    }

    public int GetCost()
    {
        return towerCost;
    }
}
