using UnityEngine;
using System.Collections;

public class setPlayerTransform : MonoBehaviour {
    private Vector3 spawn;
    public GameObject indicator;
    private GameObject player;
	
	void Start () {
        player = GameObject.Find("First Person Controller");
        spawn = new Vector3(indicator.transform.position.x,indicator.transform.position.y,indicator.transform.position.z);
        player.transform.position = spawn;
    }
}
