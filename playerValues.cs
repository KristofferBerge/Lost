using UnityEngine;
using System.Collections;

public class playerValues : MonoBehaviour {
    public float hungerDeclineRate;
    private float health;
    private float drugs;
    public bool hungry = true;

    public GameObject uiScript;
    private uiUpdate update;

    void awake() { 
        
    }
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        uiScript.GetComponent<uiUpdate>().setCurrentHunger(hungerDeclineRate*Time.deltaTime);

	}
}
