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

    void Awake() {
        whiteOut = GameObject.Find("WhiteOut");
        uiScript = GameObject.Find("UI-script");
    }

    void OnLevelWasLoaded() {
        if (Application.loadedLevelName == "bunker") {
            timerCanvas = GameObject.Find("Timer-Canvas");
            if (!missionRunning){
                uiScript.GetComponent<uiUpdate>().setClockVisible();
                counter = 180;
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
        camTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
	}

	void Update () {
        if (missionRunning){
            counter -= Time.deltaTime;
            if (counter < 1){
                counter = 0;
                if (!endingRunning){
                    StartCoroutine(startWhiteOut());
                    endingRunning = true;
                    StartCoroutine(cameraShake());
                }
            }
            if (Application.loadedLevelName == "bunker"){
                timerCanvas.GetComponentInChildren<Text>().text = (int)counter + "";
            }
            uiClock.GetComponent<Text>().text = (int)counter + "";
        }
	}

    private IEnumerator startWhiteOut() {
        yield return new WaitForSeconds(2);
        whiteOut.GetComponent<Image>().CrossFadeAlpha(1, 5, false);
        yield return new WaitForSeconds(5);
        pauseGame pauseScript = GameObject.Find("UI-script").GetComponent<pauseGame>();
        StopAllCoroutines();
        pauseScript.setDead(true);
        pauseScript.setPause();
    }

    private IEnumerator cameraShake() {
        Vector3 orginalPos = camTransform.transform.localPosition;
        while (endingRunning) {
            camTransform.localPosition = orginalPos + Random.insideUnitSphere * shakeIntensity;
            yield return new WaitForSeconds(0.1f);
        }
        camTransform.localPosition = orginalPos;
    }
    public void resetCounter() {
        counter = 181;
    }
}
