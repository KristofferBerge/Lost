using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    private float counter;
    private GameObject uiClock;
    private GameObject uiScript;
    private string missionText = "Coundown mission enabled!";
    private GameObject whiteOut;
    private bool missionRunning;
    private bool endingRunning;
    private Transform camTransform;
    public float shakeIntensity;
    private GameObject timerCanvas;
    public AudioSource lydkilde;

    void Awake() {
        //Get references to neccesary scripts for later.
        whiteOut = GameObject.Find("WhiteOut");
        uiScript = GameObject.Find("UI-script");
    }

    void OnLevelWasLoaded() {
        //If player is in bunker. Find canvas on computer screen.
        if (Application.loadedLevelName == "bunker") {
            timerCanvas = GameObject.Find("Timer-Canvas");
            //Starts mission if not allready running
            if (!missionRunning){
                uiScript.GetComponent<uiUpdate>().setClockVisible();
                counter = 180;
                //Writes out missiontext
                uiScript.GetComponent<postMissionText>().printMissionText(missionText);
                missionRunning = true;
                uiClock = GameObject.Find("clockText");
            }
        }
    }

	// Use this for initialization
	void Start () {
        missionRunning = false;
        endingRunning = false;
        //Stores reference to main camera for shake effect later
        camTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
	}

	void Update () {
        if (missionRunning){
            //Reduces timer with 1 every 1 second.
            counter -= Time.deltaTime;
            if (counter < 1){
                counter = 0;
                //Start whiteout and camera shake when timer is 0 and ending not allready running.
                if (!endingRunning){
                    StartCoroutine(startWhiteOut());
                    endingRunning = true;
                    StartCoroutine(cameraShake());
                }
            }
            //Updates display on computer screen if player is in bunker
            if (Application.loadedLevelName == "bunker"){
                timerCanvas.GetComponentInChildren<Text>().text = (int)counter + "";
            }
            //Updates ui-timer display
            uiClock.GetComponent<Text>().text = (int)counter + "";
        }
	}

    private IEnumerator startWhiteOut() {
        //Let the camera shake for 3 seconds before whiteout
        yield return new WaitForSeconds(3);
        //Fade in white overlay image on camvas
        whiteOut.GetComponent<Image>().CrossFadeAlpha(1, 5, false);
        //Let it fade in for 5 seconds
        yield return new WaitForSeconds(5);
        //Game over
        pauseGame pauseScript = GameObject.Find("UI-script").GetComponent<pauseGame>();
        StopAllCoroutines();
        pauseScript.setDead(true);
        pauseScript.setPause();
    }

    private IEnumerator cameraShake() {
        //Play earthquake sound
        lydkilde.Play();
        //Store original camera position relative to controller
        Vector3 orginalPos = camTransform.transform.localPosition;
        while (endingRunning) {
            //Set camera position to random positions within radius from original cameraposition
            camTransform.localPosition = orginalPos + Random.insideUnitSphere * shakeIntensity;
            //Wait 0.1 second and repeat untill game over
            yield return new WaitForSeconds(0.1f);
        }
        camTransform.localPosition = orginalPos;
    }
    //Resets timer
    public void resetCounter() {
        counter = 181;
    }
}
