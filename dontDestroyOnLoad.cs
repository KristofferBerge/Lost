using UnityEngine;
using System.Collections;

public class dontDestroyOnLoad : MonoBehaviour {
    public GameObject canvas;
    public GameObject persistant;
    public GameObject player;

	void Awake () {
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(persistant);
        DontDestroyOnLoad(player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
