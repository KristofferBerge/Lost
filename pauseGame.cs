using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour {
    public GameObject pauseMenu;
    
    //Protected by dontDestroyOnLoad
    public GameObject canvas;
    public GameObject persistant;
    public GameObject player;
    
    public void hidePauseMenu() {
        //Removing pause menu from canvas
        pauseMenu.SetActive(false);
        //Starts game physics
        Time.timeScale = 1;
        //Unlocks FPS-controller looking function in both X and Y direction
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().setPause(false);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().setPause(false);
    }

    public void setPause() {
        //Adding pause menu to canvas
        pauseMenu.SetActive(true);
        //Pausing game physics
        Time.timeScale = 0;
        //Locks FPS-controller looking function in both X and Y direction
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().setPause(true);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().setPause(true);
    }
    
    //Exiting the game
    public void mainMenu() {
        //Destroying game objects protected by dontDestroyOnLoad
        Destroy(canvas);
        Destroy(persistant);
        Destroy(player);
        //Loading main menu
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