using UnityEngine;
using System.Collections;

public class drugMission : MonoBehaviour {
    private bool missionEnabled;
    private GameObject drugsBar;

    public void takeDrugs(){
        if (!missionEnabled){
            drugsBar.SetActive(true);
            GameObject.Find("UI-script").GetComponent<postMissionText>().printMissionText("Great, you are now hooked on drugs. Make sure you feed your newly acquired habit...");
            GameObject.Find("Persistant").GetComponent<playerValues>().enableDrugDecline();
            missionEnabled = true;
        }
        else {
            GameObject.Find("UI-script").GetComponent<uiUpdate>().setCurrentDrug(30);
        }
    }
    public void overflow(float i) {
        if (i > 10) {
            GameObject.Find("UI-script").GetComponent<postMissionText>().printMissionText("Dude, be carefull! This is some strong shit...");
            GameObject.Find("UI-script").GetComponent<uiUpdate>().setCurrentHealth(50);
            GameObject.Find("DamageOverlay").GetComponent<VisualizeDamage>().displayDamageOverlay();
        }

    }
	// Use this for initialization
	void Start () {
        missionEnabled = false;
        //Storing reference to object before setting inactive
        drugsBar = GameObject.Find("drugsBar");
        drugsBar.SetActive(false);
	}
}
