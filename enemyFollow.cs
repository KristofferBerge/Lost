using UnityEngine;
using System.Collections;

public class enemyFollow : MonoBehaviour {
    private GameObject player;
    private Vector3 startPos;
    //0.01 is impossible to escape
    public float mobSpeed;
    private bool isFollowing;
    //When player enters trigger collider, enemy starts following player.
    void OnTriggerStay(Collider other) {
        if (other == player.GetComponent<Collider>()) {
                transform.position = Vector3.Lerp(transform.position, player.transform.position, mobSpeed);
                Vector3 playerPos = player.transform.position;
                transform.LookAt(playerPos);
        }
    }
    //Setting bool false when not following.
    void OnTriggerExit() {
        isFollowing = false;
    }
    //setting bool true when following.
    void OnTriggerEnter() {
        isFollowing = true;
    }

	// Use this for initialization
	void Start () {
        player = GameObject.Find("First Person Controller");
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        isFollowing = false;
	}
	
	// Update is called once per frame
	void Update () {

        //When enemy is not following it goes back to starting position.
        if (!isFollowing){
            transform.position = Vector3.Lerp(transform.position, startPos, mobSpeed/2);
            transform.LookAt(startPos);
        }
	}
}
