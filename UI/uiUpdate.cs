using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiUpdate : MonoBehaviour {

	//Variables for health
	public int maxHealth;
	public RectTransform healthTransform;
	private int currentHealth;
	private float healthBarUnit;
	private float currentHealthXValue;
	private float healthYValue;

    //Damage
    public GameObject damageIcon;
    public Text damageTxt;

	//Variables for hunger
	public int maxHunger;
	public RectTransform hungerTransform;
	private int currentHunger;
	private float hungerBarUnit;
	private float currentHungerXValue;
	private float hungerYValue;

	//Variables for drugs
	public int maxDrugs;
	public RectTransform drugsTransform;
	private int currentDrugs;
	private float drugsBarUnit;
	private float currentDrugsXValue;
	private float drugsYValue;

	//variables for health and hunger
	private float minXValue;
	private float maxXValue;

    //Storing reference to uiClock
    private GameObject uiClock;
    private GameObject whiteOut;

    //Debugging
    public Text debugText;

	//Public setters. 
	public void setCurrentHealth(float delta){
		currentHealthXValue = currentHealthXValue - (delta * healthBarUnit);
        //Making sure health does not exceed max value
        if (currentHealthXValue > maxXValue) {
            currentHealthXValue = maxXValue;
        }
        //Making sure health does not exceed min value
        else if (currentHealthXValue < minXValue) {
            currentHealthXValue = minXValue;
            playerDead();
        }
        //Sets new health value in UI
            healthTransform.localPosition = new Vector3(currentHealthXValue, healthYValue);
	}
	public void setCurrentHunger(float delta){
		currentHungerXValue += (delta * hungerBarUnit);
        //Making sure hunger does not exceed max value
        if (currentHungerXValue > maxXValue) {
            currentHungerXValue = maxXValue;
        }
        //making sure hunger does not exceed min value
        else if (currentHungerXValue < minXValue) {
            currentHungerXValue = minXValue;
        }
        //Sets new health value in UI
        hungerTransform.localPosition = new Vector3(currentHungerXValue, hungerYValue);
	}
    public float getCurrentHunger() {
        return (currentHungerXValue - minXValue) / hungerBarUnit;
    }
    //DEBUGGING
    public float getCurrentHealth()
    {
        return (currentHealthXValue - minXValue) / healthBarUnit;
    }
    //DEBUGGING
    public float getCurrentDrugs()
    {
        return (currentDrugsXValue - minXValue) / drugsBarUnit;
    }
    //Sets value on drug-bar
	public void setCurrentDrug(float delta){
        currentDrugsXValue += (delta * drugsBarUnit);

        if (currentDrugsXValue > maxXValue) {
            float overflow;
            overflow = ((currentDrugsXValue - minXValue) /drugsBarUnit) - maxDrugs;
            currentDrugsXValue = maxXValue;
            GameObject.Find("Persistant").GetComponent<drugMission>().overflow(overflow);
        }
        else if (currentDrugsXValue < minXValue) {
            currentDrugsXValue = minXValue;
        }
        drugsTransform.localPosition = new Vector3(currentDrugsXValue, drugsYValue);
	}
    //Display damage indicator and number to show how much damage the player has taken.
    public void displayDamage(int i) {

        if (i > 0) {
            damageIcon.SetActive(true);
            damageTxt.text = i + "";
        }
        else {
            damageIcon.SetActive(false);
            damageTxt.text = "";
        }
    }

    //Sets the countdown clock visible on canvas
    public void setClockVisible() {
        uiClock.SetActive(true);
    }

	void Start () {
		//set coordinates
		minXValue = healthTransform.localPosition.x - healthTransform.rect.width;
		maxXValue = healthTransform.localPosition.x;
		healthYValue = healthTransform.localPosition.y;
		hungerYValue = hungerTransform.localPosition.y;
		drugsYValue = drugsTransform.localPosition.y;
		//set barUnits. (Should be called if increase/decrease in max hunger and/or health is enabled @runtime)
		healthBarUnit = (maxXValue - minXValue) / maxHealth;
		hungerBarUnit = (maxXValue - minXValue) / maxHunger;
		drugsBarUnit = (maxXValue - minXValue) / maxDrugs;
        GameObject.Find("miniMapCam").GetComponent<Camera>().depth = -1;
        uiClock = GameObject.Find("clockBg");
        uiClock.SetActive(false);
        whiteOut = GameObject.Find("WhiteOut");
        whiteOut.GetComponent<Image>().CrossFadeAlpha(0, 0.1f, true);
	}



	// Update is called once per frame
	void Update () {
        //Not the best way to lock rotation on the minimap.
        GameObject.Find("miniMapCam").transform.eulerAngles = new Vector3(90,0,0);
       
        //DEBUGGING
        //debugText.text = "Health:" + getCurrentHealth() + " Hunger:" + getCurrentHunger() + "Drugs:" + getCurrentDrugs();
    }

    void playerDead() {
        //Sets player to dead to show kill screen
        pauseGame pauseScript = GameObject.Find("UI-script").GetComponent<pauseGame>();
        pauseScript.setDead(true);
    }

    
    
}