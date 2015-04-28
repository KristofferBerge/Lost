using UnityEngine;
using System.Collections;

public class BoatMovement : MonoBehaviour {
    public int travelDistance;
    public float speed;
    private Vector3 startPos;
    private Vector3 toPos;

    void OnTriggerEnter(Collider other) {
        //When something comes close to the boat, the boat will go out to sea
        startPos = transform.position;
        toPos = new Vector3(startPos.x + travelDistance, startPos.y, startPos.z);
        StartCoroutine(moveBoat());
    }
    private IEnumerator moveBoat() { 
        while(Vector3.Distance(toPos,transform.position) > 1){
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }
}
