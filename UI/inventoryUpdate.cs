using UnityEngine;
using System.Collections;

public class inventoryUpdate : MonoBehaviour {

	//Storing UI-sprites
	public GameObject invPos;
	public GameObject uEmpty;
	public GameObject sEmpty;
    public GameObject uBanana;
    public GameObject sBanana;
    public GameObject uFirstAid;
    public GameObject sFirstAid;
    public GameObject uCoconut;
    public GameObject sCoconut;
    public GameObject uMap;
    public GameObject sMap;
    public GameObject uDrugs;
    public GameObject sDrugs;
    public GameObject uAk;
    public GameObject sAk;

	//Storing positions, selection and inventory
    public int numberOfSlots;
	public float slotSize;
	private float posX;
	private float posY;
	private int currentSlot;
	private int[] inventoryArr;
	private float negOffset;

	//updates the UI-sprites to match the state of the inventory
	private void updateInventory() {

		//Removes old sprites from canvas before adding new
		GameObject[] toDelete;
		toDelete = GameObject.FindGameObjectsWithTag ("inventory");
		foreach (GameObject g in toDelete) {
			Destroy(g);
		}

		//check which sprite to draw
		for (int i = 0; i < numberOfSlots; i++) {

			//Selects the "selected" sprite to be instantiated
			if(i == currentSlot){
                showGun(false);
				switch (inventoryArr[i]){
					case 0:
						createSlot(i, sEmpty);
						break;
                    case 1:
                        createSlot(i, sBanana);
                        break;
                    case 2:
                        createSlot(i, sFirstAid);
                        break;
                    case 3:
                        createSlot(i, sCoconut);
                        break;
                    case 4:
                        createSlot(i, sMap);
                        break;
                    case 5:
                        createSlot(i, sDrugs);
                        break;
                    case 6:
                        createSlot(i, sAk);
                        showGun(true);
                        break;
				}
			}

			//Selects the "unselected" sprites to be instantiated
			else{
				switch (inventoryArr[i]){
				case 0:
					createSlot(i, uEmpty);
					break;
                case 1:
                    createSlot(i, uBanana);
                    break;
                case 2:
                    createSlot(i, uFirstAid);
                    break;
                case 3:
                    createSlot(i, uCoconut);
                    break;
                case 4:
                    createSlot(i, uMap);
                    break;
                case 5:
                    createSlot(i, uDrugs);
                    break;
                case 6:
                    createSlot(i, uAk);
                    break;
				}
			}
		}
	}

	//Instantiates sprite, sets parent and tag
	private void createSlot(int i, GameObject sprite){
			GameObject slot = Instantiate (sprite, new Vector3((posX + (slotSize*i)-negOffset),posY,0),Quaternion.identity) as GameObject;
			slot.transform.SetParent (this.transform);
			slot.tag = "inventory";
	}

	//Sets selected slot to oposite end of array if selected slot is outside of range
	private void checkCurrentSlot(){
		if(currentSlot < 0){
			currentSlot = numberOfSlots - 1;
		}
		else if(currentSlot > numberOfSlots -1){
			currentSlot = 0;
		}
		updateInventory ();
	}

    //Raycast will ask if selected slot is empty when player tries to pick up object
    public bool getSelectedSlot(){
        if (inventoryArr[currentSlot] == 0) {
            return true;
        }
        else {
            return false;
        }
    }
    public int getSelectedItem() {
        return inventoryArr[currentSlot];
    }
    //Adds item identification number to inventory-array and refreshes inventory-sprites
    //rayCast calls this function after first asking inventory for item-id
    public void addItem(int i) {
        inventoryArr[currentSlot] = i;
        updateInventory();
    }
    //Enhancement added instead of rewriting entire inventory script
    //Adds item to free slot when current slot is full
    public bool addItemToSpecificSlot(int itemId) {
        int freeSlot = findFreeSlot();
        if (freeSlot >= 0){
            inventoryArr[freeSlot] = itemId;
            updateInventory();
            return true;
        }
        else {
            return false;
        }
    }
    //Checks array to find free slot
    private int findFreeSlot() {
        for (int i = 0; i < numberOfSlots; i++) {
            if (inventoryArr[i] == 0) {
                return i;
            }
        }
        return -1;
    }
    //Removes item from inventory 
    public void removeItem (){
        inventoryArr[currentSlot] = 0;
        updateInventory();
    }
	// Use this for initialization
	void Start () {
		//sets negative offset for inventory 
		negOffset = (slotSize * 3.5f);

		//Creates empty inventory array
		inventoryArr = new int[numberOfSlots];
		for(int i = 0; i < numberOfSlots; i++){
            inventoryArr[i] = 0;
		}
        inventoryArr[3] = 1;
        inventoryArr[4] = 2;
		//sets current selected slot and gets position of inventory from dummy-sprite placed on canvas
		currentSlot = 1;
		posX = invPos.transform.position.x;
		posY = invPos.transform.position.y;

		//Instantiates the inventory
		updateInventory ();
	
	}

    public int getNumberOfSlots() { 
        return numberOfSlots;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			currentSlot -= 1;
			checkCurrentSlot ();
		} 

		else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			currentSlot += 1;
			checkCurrentSlot();
		}
        else if(Input.GetKeyUp("1")){
            currentSlot = 0;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("2"))
        {
            currentSlot = 1;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("3"))
        {
            currentSlot = 2;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("4"))
        {
            currentSlot = 3;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("5"))
        {
            currentSlot = 4;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("6"))
        {
            currentSlot = 5;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("7"))
        {
            currentSlot = 6;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("8"))
        {
            currentSlot = 7;
            checkCurrentSlot();
        }
        else if (Input.GetKeyUp("9"))
        {
            currentSlot = 8;
            checkCurrentSlot();
        }
	}
    private void showGun(bool show) {
        if (show) {
            GameObject.Find("First Person Controller").GetComponent<WheaponController>().showWheapon(true);
        }
        else{
            GameObject.Find("First Person Controller").GetComponent<WheaponController>().showWheapon(false);
        }
    }
}
