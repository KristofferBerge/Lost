using UnityEngine;
using System.Collections;

public class loadActualGame : MonoBehaviour {

	void Start () {
        PlayerInitPos playerPosition = GameObject.Find("Persistant").GetComponent<PlayerInitPos>();
        //Set spawn when main scene loads
        playerPosition.setSpawn("beach");
        Application.LoadLevel("main");
	}
	
}
