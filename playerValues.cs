using UnityEngine;
using System.Collections;

public class playerValues : MonoBehaviour {
    public float hungerDeclineRate;
    public float healthDeclineRate;
    public float healthInclineRate;
    public float drugsDeclineRate;
    private int damage;
    private float health;
    private float drugs;
    private bool drugEnabled;


    public GameObject uiScript;
    private uiUpdate update;

    public void addDamage(int i) {
        damage += i;
        
        //Sets max damage to 5
        if (damage > 5){
            damage = 5;
        }
        
        uiScript.GetComponent<uiUpdate>().displayDamage(damage);
    }

    public void enableDrugDecline() {
        drugEnabled = true;
    }

	// Use this for initialization
	void Start () {
        damage = 0;
        uiScript.GetComponent<uiUpdate>().displayDamage(damage);
        drugEnabled = false;
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("p"))
        {
           uiScript.GetComponent<uiUpdate>().setCurrentHunger(10);
        }

        //Slowly decreases the hunger
        uiScript.GetComponent<uiUpdate>().setCurrentHunger(hungerDeclineRate * Time.deltaTime);

        //Slowly decreases the drug-bar
        if (drugEnabled) {
            uiScript.GetComponent<uiUpdate>().setCurrentDrug(drugsDeclineRate * Time.deltaTime);
        }

        //Slowly decreases the health if damage > 0
        if (damage > 0) {
            uiScript.GetComponent<uiUpdate>().setCurrentHealth(healthDeclineRate * Time.deltaTime * damage);
        }
        //Decreases the health if hunger is < 10
        if (uiScript.GetComponent<uiUpdate>().getCurrentHunger() < 10) {
            uiScript.GetComponent<uiUpdate>().setCurrentHealth(healthDeclineRate * Time.deltaTime);
        }
        //Increases the health if hunger > 50 and damage = 0
        if (uiScript.GetComponent<uiUpdate>().getCurrentHunger() > 50 && damage == 0) {
            uiScript.GetComponent<uiUpdate>().setCurrentHealth(healthInclineRate * Time.deltaTime);
        }
	}
}
