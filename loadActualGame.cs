using UnityEngine;
using System.Collections;

public class loadActualGame : MonoBehaviour {

	void Start () {
        PlayerInitPos playerPosition = GameObject.Find("Persistant").GetComponent<PlayerInitPos>();
        playerPosition.setSpawn("hatch");
        Application.LoadLevel("main");
	}
	
}
