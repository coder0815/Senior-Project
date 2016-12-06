using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Change_Tower_Cursor : MonoBehaviour {

    public Texture2D targetReticle;
    public Sprite cancelImage;
    public Sprite  towerImage;
    public CursorMode mode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Button button;
    public SpawnTower spawnTower;

    private bool cancelActive = false;

    // Use this for initialization
    void Start()
    {
        spawnTower = gameObject.GetComponent<SpawnTower>();

        button = gameObject.GetComponent<Button>();

        // Event listeners for changing the texture image of the button
        button.onClick.AddListener(ChangeCursorTextureForAbility);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Set curso to be a target reticle for placement of abilities
    void ChangeCursorTextureForAbility()
    {
        if (button.image.sprite == towerImage && !cancelActive)
        {
            if (spawnTower.GetCost() <= GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>().GetCurrency())
            {
                Cursor.SetCursor(targetReticle, hotSpot, mode);
                button.image.sprite = cancelImage;
                spawnTower.TowerCost = gameObject.GetComponentInChildren<Text>().text;
                ChangeCancelActive();
                button.onClick.AddListener(ChangeCancelActive);
                spawnTower.ChangeReadyState();

            }
        }
        else if (button.image.sprite == cancelImage && cancelActive)
        {
            ChangeCancelActive();
            ChangeCursorBack();
            button.image.sprite = towerImage;                                    
            spawnTower.ChangeReadyState();
        }
       
        
    }


    //Revert cursor back to default.
    public void ChangeCursorBack()
    {
        Cursor.SetCursor(null, Vector2.zero, mode);
        button.image.sprite = towerImage;
        
    }

    public  void ChangeCancelActive()
    {
        cancelActive = !cancelActive;
    }
}
