using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rayCast : MonoBehaviour {
    float x;
    float y;
    public Text disp;

	// Use this for initialization
	void Start () {

        //Finding and setting center point on screen to match crosshair
        x = Screen.width/2;
        y = Screen.height/2;
        //Locking mouse pointer
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

       Ray ray = Camera.main.ScreenPointToRay(new Vector3(x,y));
       RaycastHit hit;

        //Player tries to interact with object
        if (Input.GetButton("Fire1")){
            if (Physics.Raycast(ray, out hit, 10)) {
                    //If object can be picked up
                    if (hit.collider.tag == "pickup")
                    {
                        Debug.Log("I CAN HAZ");
                    }
                    else
                    {
                        Debug.Log("Dis is nothin");
                    }
            }
        }

        if (Physics.Raycast(ray, out hit, 10)) {
            if (hit.collider.tag == "pickup") {
                //If ray hits object that can be picked up
                disp.text = "Right click to pick up";
            }
            else {
                disp.text = "";
            }
        }
	}
}
