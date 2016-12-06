using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Change_TargetedFireBlast_Cursor : MonoBehaviour {

    public Texture2D targetReticle;
    public Sprite fireImage;
    public Sprite cancelImage;
    public CursorMode mode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Button button;
    private TargetedFireBlast targetedFireBlast;

    private bool cancelActive = false;


    GameObject[] abilities;
    // Use this for initialization
    void Start()
    {

        // making adjustments so that we can use one script
        // and check which ability is active in the game
        // and access that abilities changereadystate method.
        targetedFireBlast = gameObject.GetComponent<TargetedFireBlast>();



        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ChangeCursorTextureForAbility);
    }

    // Update is called once per frame
    void Update()
    {
        // cancels casting ability and changes cursor and image for button back to normal
        if (Input.GetKeyUp(KeyCode.X) && button.image.sprite == cancelImage && cancelActive)
        {
            ChangeCursorBack();
            changeCancelActive();
            targetedFireBlast.ChangeReadyState();
        }
    }

    public void changeCancelActive()
    {
        cancelActive = !cancelActive;
    }

    //Set curso to be a target reticle for placement of abilities
    void ChangeCursorTextureForAbility()
    {
        if (button.image.sprite == fireImage && !cancelActive)
        {
            changeCancelActive();
            Cursor.SetCursor(targetReticle, hotSpot, mode);
            button.image.sprite = cancelImage;
            targetedFireBlast.ChangeReadyState();
        }

    }


    //Revert cursor back to default.
    public void ChangeCursorBack()
    {
        Cursor.SetCursor(null, Vector2.zero, mode);
        button.image.sprite = fireImage;
    }
}
