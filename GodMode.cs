using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour {
    private bool godMode;
    public GameObject fpc;
    void Start() {
        godMode = false;
    }
	// Update is called once per frame
	void Update () {
        if (!godMode) { 
            if(Input.GetKey("g")){
                if(Input.GetKey("a")){
                    Debug.Log("GODMODE ACTIVATED");
                    godMode = true;
                }
            }
        }

        else{
            if(Input.GetKey("g")){
                if (Input.GetKey("1")) {
                    //Teleport to beach
                    fpc.transform.position = new Vector3(274, 3.9f, 267);
                }
                else if (Input.GetKey("2"))
                {
                    //Teleport to hatch
                    fpc.transform.position = new Vector3(347, 18.4f, 631);
                }
                else if (Input.GetKey("3"))
                {
                    //Teleport to Other beach
                    fpc.transform.position = new Vector3(817, 25, 585);
                }
                else if (Input.GetKey("4"))
                {
                    //Teleport to mountain
                    fpc.transform.position = new Vector3(-97, 170, 412);
                }
            }
        }
	
	}
}
