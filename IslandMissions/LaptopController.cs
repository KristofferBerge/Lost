using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LaptopController : MonoBehaviour {
    public Text laptopText;

    void Start() {
        StartCoroutine(textBlink());
    }

    void OnTriggerEnter() {
        GameObject.Find("UI-script").GetComponent<postMissionText>().printMissionText("Looks like you can turn on the radar from this computer. Press 'r' to turn on the radar");
    }
    void OnTriggerStay() {
        if (Input.GetKeyUp("r")) {
            enableRadar();
            GameObject.Find("UI-script").GetComponent<postMissionText>().printMissionText("The radar detects enemies and shows them on your minimap.");
        }
    }

    private IEnumerator textBlink(){
        while (true){
            laptopText.text = "RADAR OFF";
            yield return new WaitForSeconds(1);
            laptopText.text = "";
            yield return new WaitForSeconds(1);
        }
    }

    private void enableRadar() {
        StopAllCoroutines();
        laptopText.text = "RADAR ON";
        laptopText.color = Color.green;
        //Sets enemy arrows visible
        GameObject.Find("miniMapCam").GetComponent<Camera>().cullingMask |= (1 << 8);
        GameObject.Find("towerLight").GetComponent<BlinkingLight>().startBlink();
    }
}
