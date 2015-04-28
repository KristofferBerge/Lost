using UnityEngine;
using System.Collections;

public class MenuMove : MonoBehaviour {

    void Start() {
        //When main menu is loaded from ended/paused game, the game is paused.
        //Sets timescale back to normal.
        Time.timeScale = 1;
    }

	// Update is called once per frame
	void Update () {
        //Pans the camera around the island
        transform.Translate(Vector3.left * Time.deltaTime * 4);
        transform.Translate(Vector3.up * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime/4);
	}
}
