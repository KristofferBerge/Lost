using UnityEngine;
using System.Collections;

public class inventoryUpdate : MonoBehaviour {

	//Storing UI-sprites
	public GameObject invPos;
	public GameObject uEmpty;
	public GameObject sEmpty;

	//Storing positions, selection and inventory
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
		for (int i = 0; i < 8; i++) {

			if(i == currentSlot){
				switch (inventoryArr[i]){
					case 0:
						createSlot(i, sEmpty);
						break;
				}
			}

			else{
				switch (inventoryArr[i]){
				case 0:
					createSlot(i, uEmpty);
					break;
				}
			}
		}
	}

	//instantiates sprite and sets tag
	private void createSlot(int i, GameObject sprite){
			GameObject slot = Instantiate (sprite, new Vector3((posX + (slotSize*i)-negOffset),posY,0),Quaternion.identity) as GameObject;
			slot.transform.SetParent (this.transform);
			slot.tag = "inventory";
	}

	//Sets selected slot to oposite end of array if selected slot is outside of range
	private void checkCurrentSlot(){
		if(currentSlot < 0){
			currentSlot = 7;
		}
		else if(currentSlot > 7){
			currentSlot = 0;
		}

		updateInventory ();
	}

	// Use this for initialization
	void Start () {
		//sets negative offset for inventory 
		negOffset = (slotSize * 3.5f);
		//Creates empty inventory array
		inventoryArr = new int[8];
		for(int i = 0; i < 8; i++){
			inventoryArr[i] = 0;
		}
		currentSlot = 1;

		posX = invPos.transform.position.x;
		posY = invPos.transform.position.y;

		updateInventory ();
	
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
	}
}
