using UnityEngine;
using System.Collections;

public class playerValues : MonoBehaviour {
    private float hunger;
    private float health;
    private float drugs;
    public int hungerDeclineRate;
    public bool hungry = true;

    public GameObject uiScript;
    private uiUpdate update;

    private void initHungerDecline() {
        StartCoroutine (hungerDecline());
    }

    IEnumerator hungerDecline() {
        while (hungry){
            yield return new WaitForSeconds(1);
            uiScript.GetComponent<uiUpdate>().setCurrentHunger(1);
        }
    }
    void awake() { 
        
    }
	// Use this for initialization
	void Start () {
        initHungerDecline();
	}

	// Update is called once per frame
	void Update () {
	}
}
