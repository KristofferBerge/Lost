using UnityEngine;
using System.Collections;

public class RecordSpinner : MonoBehaviour {

    private bool playing = true;
    public int speed;
    public AudioSource lydkilde;
    public GameObject arm;
    private Quaternion armPos;

    void Start() {
        //Makes a Quaternion that will be the "active" position of the arm
        armPos = arm.transform.rotation;
    }

	// Use this for initialization
    void Update() {
        //Rotates the record on the recordplayer when the song is playing
        if (playing) {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public void stopSong() {
        //Stops the spinning
        playing = false;
        //Plays the scratch sound
        lydkilde.Play();
        //Starts method that moves the arm
        StopAllCoroutines();
        StartCoroutine(moveArm(true));
    }
    public void startSong() {
        playing = true;
        StopAllCoroutines();
        StartCoroutine(moveArm(false));
    }

    private IEnumerator moveArm(bool playing) {
        while (transform.position.y > 1) {
            if (playing){
                //Moves the arm back
                arm.transform.localRotation = Quaternion.Lerp(arm.transform.rotation, Quaternion.identity, Time.deltaTime);
            }
            else {
                //Moves the arm to the "active" position
                arm.transform.localRotation = Quaternion.Lerp(arm.transform.rotation, armPos, Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
