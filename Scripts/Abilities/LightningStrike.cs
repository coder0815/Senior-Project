using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightningStrike : MonoBehaviour {

    

    public GameObject lightning;
    public Texture2D targetReticle;
    private Change_LightningStrike_Cursor cursor;
    
    public float lengtgOfLightingStrike = 5;
    public float timeSinceActivated = 0;
    public bool offCoolDown = true;
    public bool isReady = true;
    public float coolDown = 0.0f;
    public Text cdText;
    public Button skillButton;
    
    

    Ray ray;
    public RaycastHit hit;
	// Use this for initialization
	void Start ()
    {
        cursor = GetComponent<Change_LightningStrike_Cursor>();    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (coolDown > 0)
        {
            string cdString = "";
            if (coolDown > 60)
            {
                if (coolDown % 60 > 10)
                    cdString = "1:" + Mathf.Ceil(((coolDown - 60) % 60)).ToString();
                else
                    cdString = "1:0" + Mathf.Ceil(((coolDown - 60) % 60)).ToString();
            }
            else
            {
                if(coolDown > 10)
                    cdString = "0:" + Mathf.Ceil((coolDown % 60)).ToString();
                else
                    cdString = "0:0" + Mathf.Ceil((coolDown % 60)).ToString();
            }
            cdText.text = cdString;
            coolDown -= Time.deltaTime;
        }
        else
        {
            offCoolDown = true;
            cdText.enabled = false;
            skillButton.enabled = true;
        }

        // If lightning strike is ready to be activated instantiate the particle effect
        if (isReady && offCoolDown)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                
               ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
               if (Physics.Raycast(ray,out hit,100))
                {
                    offCoolDown = false;
                    coolDown = 105.0f;
                    cdText.enabled = true;
                    skillButton.enabled = false;
                    Instantiate(lightning, hit.point, transform.rotation);
                    ChangeReadyState();
                    cursor.ChangeCursorBack();
                    cursor.changeCancelActive();
                    Destroy(GameObject.FindGameObjectWithTag("Lightning"), 2.75f);
                   
                }              
                
            }

        }
        //if (lightning != null)
        //{
        //    timeSinceActivated += Time.deltaTime;
        //    Debug.Log(timeSinceActivated);
        //    if (timeSinceActivated >= lengtgOfLightingStrike)
        //    {
        //        Destroy(GameObject.FindGameObjectWithTag("Lightning"));
        //        timeSinceActivated = 0;
        //    }
        //}
        
	}

    // Set state of the ability to not ready to prevent multiple instantiations at once.
    public void ChangeReadyState()
    {
        isReady = !isReady;
    }
   

}
