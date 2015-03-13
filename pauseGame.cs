using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour {
    public GameObject pauseMenu;
    
    //Protected by dontDestroyOnLoad
    public GameObject canvas;
    public GameObject persistant;
    public GameObject player;
    
    public void hidePauseMenu() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().setPause(false);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().setPause(false);
    }

    public void setPause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().setPause(true);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().setPause(true);
            
    }
    public void mainMenu() {
        Destroy(canvas);
        Destroy(persistant);
        Destroy(player);
        Application.LoadLevel("menu");
    }
	// Use this for initialization
	void Start () {
        hidePauseMenu();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape")){
            setPause();
        }
	}
}