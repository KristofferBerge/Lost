using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    private float counter;
    public GameObject timerCanvas;
    private GameObject uiClock;
    private GameObject uiScript;
    private string missionText = "Coundown mission enabled!";
    private GameObject whiteOut;
    private bool endingRunning;
    private Transform camTransform;
    public float shakeIntensity;

    void Awake() {
        whiteOut = GameObject.Find("WhiteOut");
    }


	// Use this for initialization
	void Start () {
        uiScript = GameObject.Find("UI-script");
        uiScript.GetComponent<uiUpdate>().setClockVisible();
        counter = 10;
        uiClock = GameObject.Find("clockText");
        uiScript.GetComponent<postMissionText>().printMissionText(missionText);
        endingRunning = false;
        camTransform = GameObject.Find("Main Camera").GetComponent<Transform>();


	}

	void Update () {
        counter -= Time.deltaTime * 1;
        if (counter < 1) {
            counter = 0;
            if (!endingRunning){
                StartCoroutine(startWhiteOut());
                endingRunning = true;
                StartCoroutine(cameraShake());
            }
        }
        timerCanvas.GetComponentInChildren<Text>().text = (int)counter + "";
        uiClock.GetComponent<Text>().text = (int)counter + "";
        
	}

    private IEnumerator startWhiteOut() {
        yield return new WaitForSeconds(2);
        whiteOut.GetComponent<Image>().CrossFadeAlpha(1, 10, false);
    }

    private IEnumerator cameraShake() {
        Debug.Log("function started");
        Vector3 orginalPos = camTransform.transform.localPosition;
        while (endingRunning) {
            Debug.Log("While running");
            camTransform.localPosition = orginalPos + Random.insideUnitSphere * shakeIntensity;
            yield return new WaitForSeconds(0.1f);
        }
        camTransform.localPosition = orginalPos;
    }
}
