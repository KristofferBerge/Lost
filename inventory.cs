using UnityEngine;
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
                Debug.Log("You ate a banana");
                removeItem();
                break;
            case 2:
                Debug.Log("You used a first aid kit");
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
