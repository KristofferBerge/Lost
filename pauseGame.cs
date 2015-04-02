using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject killScreen;
    
    //Protected by dontDestroyOnLoad
    private GameObject canvas;
    private GameObject persistant;
    private GameObject player;
    private bool isDead;
    
    public void hidePauseMenu() {
        //Removing pause menu from canvas
        pauseMenu.SetActive(false);
        //Starts game physics
        Time.timeScale = 1;
        //Unlocks FPS-controller looking function in both X and Y direction
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().setPause(false);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().setPause(false);
        Cursor.visible = false;
    }

    public void setPause() {
        Cursor.visible = true;
        //Pausing game physics
        Time.timeScale = 0;
        //Locks FPS-controller looking function in both X and Y direction
        GameObject.Find("First Person Controller").GetComponent<MouseLook>().setPause(true);
        GameObject.Find("Main Camera").GetComponent<MouseLook>().setPause(true);
        if (isDead){
            setKillScreen();
        }
        else{
            setPauseMenu();
        }
    }
    public void restart() {
        //Destroying game objects protected by dontDestroyOnLoad
        Destroy(canvas);
        Destroy(persistant);
        Destroy(player);
        //Loading setup-scene
        Application.LoadLevel("fpcLoader");
    }

    public void setKillScreen(){
        killScreen.SetActive(true);
    }
    public void setPauseMenu() {
        pauseMenu.SetActive(true);
    }

    public void setDead(bool boolean) {
        isDead = boolean;
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
        killScreen = GameObject.Find("KillScreen");
        killScreen.SetActive(false);
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("First Person Controller");
        persistant = GameObject.Find("Persistant");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape")){
            setPause();
        }
	}
}