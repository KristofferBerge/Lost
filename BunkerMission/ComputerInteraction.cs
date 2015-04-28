using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComputerInteraction : MonoBehaviour {
    private Text toolTip;
    private bool isUsing;
    private GameObject player;
    private CharacterMotor playerController;
    private MouseLook playerLook;
    private MouseLook cameraLook;
    private Quaternion operatingRotation;
    private int operatingRotationAngle = 0;
    private postMissionText missionText;
    private Text computerDisplay;
    private string theNumbers;
    private CountDown counter;
    void Awake() {
        toolTip = GameObject.Find("toolTipText").GetComponent<Text>();
        player = GameObject.Find("First Person Controller");
        cameraLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        playerController = player.GetComponent<CharacterMotor>();
        playerLook = player.GetComponent<MouseLook>();
        missionText = GameObject.Find("UI-script").GetComponent<postMissionText>();
        computerDisplay = GameObject.Find("ComputerDisplayText").GetComponent<Text>();
    }
    void Start(){
        operatingRotation = Quaternion.Euler(0, operatingRotationAngle, 0);
        StartCoroutine(idleState());
    }

    void OnTriggerStay(Collider other){
        if (other.tag == "Player"){
            if (!isUsing) {
                toolTip.text = "Press 'r' to use computer";
            }
        }

        if (Input.GetKeyUp("r")){
            if (isUsing){
                unlockMovement();
            }
            else{
                lockMovement();
                StopAllCoroutines();
            }
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            toolTip.text = "";
        }
    }

    private void lockMovement() {
        playerController.enabled = false;
        playerLook.enabled = false;
        cameraLook.enabled = false;
        isUsing = true;
        missionText.printMissionText("Use the number keys to enter the code. Press 'r' again to abort.");
    }
    private void unlockMovement(){
        playerController.enabled = true;
        playerLook.enabled = true;
        cameraLook.enabled = true;
        isUsing = false;
        StartCoroutine(idleState());
    }

    private IEnumerator lookAtComputer() {
        while (Quaternion.Angle(player.transform.rotation, operatingRotation) > 1) {
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, operatingRotation, 0.2f);
            yield return null;
        }
    }

    void Update (){
        //Getting keyboard input when player is using the computer
        if(isUsing){

            if (Input.GetKeyUp(KeyCode.Keypad0) || Input.GetKeyUp("0"))
            {
                theNumbers += "0";
                displayNumbers();
            }
            if (Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp("1"))
            {
                theNumbers += "1";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp("2"))
            {
                theNumbers += "2";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp("3"))
            {
                theNumbers += "3";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp("4"))
            {
                theNumbers += "4";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp("5"))
            {
                theNumbers += "5";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp("6"))
            {
                theNumbers += "6";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad7) || Input.GetKeyUp("7"))
            {
                theNumbers += "7";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp("8"))
            {
                theNumbers += "8";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Keypad9) || Input.GetKeyUp("9"))
            {
                theNumbers += "9";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                theNumbers += " ";
                displayNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter) ){
                Debug.Log("Enter pressed");
                checkNumbers();
            }
            else if (Input.GetKeyUp(KeyCode.Backspace)) {
                Debug.Log("Backspace pressed");
                theNumbers = theNumbers.Remove(theNumbers.Length - 1);
                displayNumbers();
            }
        }
    }

    private void displayNumbers() {
        computerDisplay.text = ">: " + theNumbers + "▊";
    }

    private IEnumerator idleState() {
        while (true){
            computerDisplay.text = ">: ▊";
            yield return new WaitForSeconds(1);
            computerDisplay.text = ">:";
            yield return new WaitForSeconds(1);
        }
    }
    private void checkNumbers()
    {
        if (theNumbers == "4 8 15 16 23 42"){
            counter = GameObject.Find("Persistant").GetComponent<CountDown>();
            counter.resetCounter();
            theNumbers = "";
            displayNumbers();
            unlockMovement();
        }
        else {
            theNumbers = "";
            displayNumbers();
        }
    }
}
