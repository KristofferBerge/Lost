﻿using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {
    
    //Instead of adding this line over and over again in switch case below.
    private void removeItem() {
        GameObject.Find("UI-script").GetComponent<inventoryUpdate>().removeItem();
    }
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
        }
    }
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Submit")) {
            useItem(GameObject.Find("UI-script").GetComponent<inventoryUpdate>().getSelectedItem());
        }
	}
}