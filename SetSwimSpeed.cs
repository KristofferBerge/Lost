using UnityEngine;
using System.Collections;

public class SetSwimSpeed : MonoBehaviour {

    private CharacterMotor playerMove;

    void Awake() {
        playerMove = GameObject.Find("First Person Controller").GetComponent<CharacterMotor>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "WaterCollider") {
            playerMove.movement.maxForwardSpeed = 4;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "WaterCollider") {
            playerMove.movement.maxForwardSpeed = 15;
        }
    }
}
