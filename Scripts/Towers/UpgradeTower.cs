using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UpgradeTower : MonoBehaviour {


    public Button upgradeButton;
    public GameObject balistaTower2;
    public GameObject balistaTower3;
    public GameObject cannonTower2;
    public GameObject cannonTower3;
    public GameObject mageTower2;
    public GameObject mageTower3;

    private Canvas upgradeMenu;
    private Canvas message;


   
    private GameObject originalTower;
    private Currency playerGold;


	// Use this for initialization
	void Start ()
    {
        
        upgradeButton.onClick.AddListener(UpgradeTheTower);
        playerGold = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        upgradeMenu = GameObject.Find("Tower Upgrade Menu").GetComponent<Canvas>();
        message = GameObject.Find("Money Notification").GetComponent<Canvas>();

    }

    private void UpgradeTheTower()
    {
        
        GameController.ResetBuildSite();
        switch (originalTower.name)
        {
            case  "td_humans_Balista_stage1(Clone)":
                {
                    if (playerGold.GetCurrency() >= 150)
                    {
                        Instantiate(balistaTower2, originalTower.transform.position, originalTower.transform.rotation);
                        Destroy(originalTower);
                        playerGold.DecreaseCurrency(150);
                        playerGold.DisplayCurrency();
                    }  
                    else if (playerGold.GetCurrency() < 150)
                    {
                        message.enabled = true;
                        Invoke("DisableMessage", 2.5f);
                    }                           
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    
                    break;
                }
            case "td_humans_Balista_stage2(Clone)":
                {
                    if (playerGold.GetCurrency() >= 250)
                    {
                        Instantiate(balistaTower3, originalTower.transform.position, originalTower.transform.rotation);
                        Destroy(originalTower);
                        playerGold.DecreaseCurrency(250);
                        playerGold.DisplayCurrency();
                    }
                    else if (playerGold.GetCurrency() < 250)
                    {
                        message.enabled = true;
                        Invoke("DisableMessage", 2.5f);
                    }
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;

                    break;
                }
            case "td_humans_Cannon_stage1(Clone)":
                {
                    if (playerGold.GetCurrency() >= 200)
                    {
                        Instantiate(cannonTower2, originalTower.transform.position, originalTower.transform.rotation);
                        Destroy(originalTower);
                        playerGold.DecreaseCurrency(200);
                        playerGold.DisplayCurrency();
                    }
                    else if (playerGold.GetCurrency() < 200)
                    {
                        message.enabled = true;
                        Invoke("DisableMessage", 2.5f);
                    }
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;

                    break;
                }
            case "td_humans_Cannon_stage2(Clone)":
                {
                    if (playerGold.GetCurrency() >= 300)
                    {
                        Instantiate(cannonTower3, originalTower.transform.position, originalTower.transform.rotation);
                        Destroy(originalTower);
                        playerGold.DecreaseCurrency(300);
                        playerGold.DisplayCurrency();
                    }
                    else if (playerGold.GetCurrency() < 300)
                    {
                        message.enabled = true;
                        Invoke("DisableMessage", 2.5f);
                    }
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;

                    break;
                }
            case "td_humans_Magic_stage1(Clone)":
                {
                    if (playerGold.GetCurrency() >= 250)
                    {
                        Instantiate(mageTower2, originalTower.transform.position, originalTower.transform.rotation);
                        Destroy(originalTower);
                        playerGold.DecreaseCurrency(250);
                        playerGold.DisplayCurrency();
                    }
                    else if (playerGold.GetCurrency() < 250)
                    {
                        message.enabled = true;
                        Invoke("DisableMessage", 2.5f);
                    }
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;

                    break;
                }
            case "td_humans_Magic_stage2(Clone)":
                {
                    if (playerGold.GetCurrency() >= 350)
                    {
                        Instantiate(mageTower3, originalTower.transform.position, originalTower.transform.rotation);
                        Destroy(originalTower);
                        playerGold.DecreaseCurrency(350);
                        playerGold.DisplayCurrency();
                    }
                    else if (playerGold.GetCurrency() < 350)
                    {
                        message.enabled = true;
                        Invoke("DisableMessage", 2.5f);
                    }
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;

                    break;
                }
            default:
                {
                    Time.timeScale = 1.0f;
                    break;
                    

                }



        }
       
    }

    // Update is called once per frame
    void Update () {
        originalTower = GameController.towerSelected;

    }

    private void DisableMessage()
    {
        message.enabled = false;
    }
}
