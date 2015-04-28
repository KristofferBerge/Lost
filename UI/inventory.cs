using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {

    private Camera mapCam;
    //Instead of adding this line over and over again in switch case below.
    private void removeItem() {
        GameObject.Find("UI-script").GetComponent<inventoryUpdate>().removeItem();
    }

    //Identifies the object player tries to pick up by name and converts it to a number for use in switchcase and uiUpdate
    public int getItemNr(GameObject item){
        string name = item.name;
        int i = 0;
        switch (name)
        {
            case "banana":
                i = 1;
                break;
            case "firstAid":
                i = 2;
                break;
            case "coconut":
                i = 3;
                break;
            case "map":
                i = 4;
                break;
            case "pack of drugs":
                i = 5;
                break;
            case "Ak-47":
                i = 6;
                break;
        }
        
        return i;
    }

    private void useItem(int i) {
        switch (i)
        {
            case 0:
                break;
            case 1:
                //Player eats banana. Health is increased by 30
                GameObject.Find("UI-script").GetComponent<uiUpdate>().setCurrentHunger(30);
                removeItem();
                break;
            case 2:
                //Player uses first aid kit. Damage is set to 0
                GameObject.Find("Persistant").GetComponent<playerValues>().addDamage(-5);
                removeItem();
                break;
            case 3:
                //Player eats coconut. Health is increased by 20
                GameObject.Find("UI-script").GetComponent<uiUpdate>().setCurrentHunger(20);
                removeItem();
                break;
            case 4:
                //Player uses map. Minimap unlocks
                mapCam.depth = 1;
                removeItem();
                GameObject.Find("UI-script").GetComponent<postMissionText>().printMissionText("Minimap is now unlocked!");
                break;
            case 5:
                GameObject.Find("Persistant").GetComponent<drugMission>().takeDrugs();
                removeItem();
                break;
            case 6:
                //Player uses wheapon. Mouse key should be used for shooting.
                break;
        }
    }
    
	// Use this for initialization
	void Start () {
        mapCam = GameObject.Find("miniMapCam").GetComponent<Camera>();
        //sets enemy arrows to invisible by including its layer on minimap cam
        mapCam.cullingMask = ~(1 << 8);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Submit")) {
            //Gets selected item from inventory and uses it
            useItem(GameObject.Find("UI-script").GetComponent<inventoryUpdate>().getSelectedItem());
        }
	}
}
