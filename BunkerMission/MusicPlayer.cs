using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour {
    public AudioSource lydkilde;
    private bool playing = true;
    public RecordSpinner recordScript;
    private Text toolTip;

    void Awake() {
        //Stores reference to tooltip-texbox on canvas
        toolTip = GameObject.Find("toolTipText").GetComponent<Text>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //When player stands inside trigger: Display tooltip
            toolTip.text = "Press 'r' to operate record player";
        }
        //If player "uses" the recordplayer: Start or stop.
        if (Input.GetKeyDown("r"))
        {
            if (playing)
            {
                //Tells the record to stop spinning before stopping music
                recordScript.stopSong();
                lydkilde.Stop();
            }
            else
            {
                recordScript.startSong();
                Invoke("playSound", 3);
            }
            //Toggle playing
            playing = !playing;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Removes tooltip when player exits trigger
            toolTip.text = "";
        }
    }

    private void playSound() {
        //Start music
        lydkilde.Play();
    }
}
