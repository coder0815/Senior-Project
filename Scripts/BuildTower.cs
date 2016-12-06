using UnityEngine;


public class BuildTower : MonoBehaviour
{

    public Color hoverColor;

    private GameObject turret;

    private Renderer rend;

    private Color startColor;

    private Currency playerGold;

    private Canvas towerBuildMenu;

   
    

    // is the build menu active
    private bool isBuildMenuActive = false;

    // is there a tower here
    private bool hasTower = false;

    void Start()
    {
        playerGold = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
       
        towerBuildMenu = GameObject.Find("Tower Build Menu").GetComponent<Canvas>();
        towerBuildMenu.enabled = false;
        hasTower = false;
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // pause game and show tower selection menu
        if (!hasTower)
        {
            Time.timeScale = 0.0f;
            towerBuildMenu.enabled = true;
            isBuildMenuActive = true;
            if (GameController.GetBuildSite() == null)
            {
                GameController.SetBuildSite(this.gameObject);
            }
        }
        
        

    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void SwitchTowerBuildMenuState()
    {
        isBuildMenuActive = !isBuildMenuActive;
    }


    public void SwitchHasTower()
    {
        hasTower = !hasTower;
    }
}
