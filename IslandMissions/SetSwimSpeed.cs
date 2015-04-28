using UnityEngine;
using System.Collections;

public class SetSwimSpeed : MonoBehaviour {

    private CharacterMotor playerMove;

    void Awake() {
        playerMove = GameObject.Find("First Person Controller").GetComponent<CharacterMotor>();
    }
    //When player is in the water, movement is slowed down
    void OnTriggerEnter(Collider other) {
        if (other.tag == "WaterCollider") {
            playerMove.movement.maxForwardSpeed = 4;
        }
    }
    //When player no longer is in contact with water, movement is set back to normal
    void OnTriggerExit(Collider other) {
        if (other.tag == "WaterCollider") {
            playerMove.movement.maxForwardSpeed = 15;
        }
    }
}
