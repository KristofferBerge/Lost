using UnityEngine;
using System.Collections;

public class BunkerSiteTrigger : MonoBehaviour {

    private GameObject uiScript;
    private string missionText = "Looks like a hatch over there, maybe you should open it.";

    void Start()
    {
        uiScript = GameObject.Find("UI-script");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            uiScript.GetComponent<postMissionText>().printMissionText(missionText);
            //This message will self destruct
            Destroy(this);
        }
    }
}
