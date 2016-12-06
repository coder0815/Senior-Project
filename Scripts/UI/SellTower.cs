using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SellTower : MonoBehaviour {

   
    public Button sellButton;
    private Canvas upgradeMenu;
    private GameObject site;
    private GameObject originalTower;
    private Currency playerGold;
    // Use this for initialization
    void Start () {

        sellButton.onClick.AddListener(SellATower);
        playerGold = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        upgradeMenu = GameObject.Find("Tower Upgrade Menu").GetComponent<Canvas>();

    }

    private void SellATower()
    {
        site = GameController.GetBuildSite();
        GameController.ResetBuildSite();
        switch (originalTower.name)
        {
            case "td_humans_Balista_stage1(Clone)":
                {                    
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(75);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Balista_stage2(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(187);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Balista_stage3(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(375);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Cannon_stage1(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(112);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Cannon_stage2(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(262);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Cannon_stage3(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(487);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Magic_stage1(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(150);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Magic_stage2(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(337);
                    playerGold.DisplayCurrency();
                    break;
                }
            case "td_humans_Magic_stage3(Clone)":
                {
                    Destroy(originalTower);
                    site.GetComponent<BuildTower>().SwitchHasTower();
                    upgradeMenu.enabled = false;
                    Time.timeScale = 1.0f;
                    playerGold.IncreaseCurrency(600);
                    playerGold.DisplayCurrency();
                    break;
                }


        }
    }

    // Update is called once per frame
    void Update () {
        originalTower = GameController.towerSelected;
	
	}
}
