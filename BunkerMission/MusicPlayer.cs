using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour {
    public AudioSource lydkilde;
    private bool playing = true;
    public RecordSpinner recordScript;
    private Text toolTip;

    void Start() {
        toolTip = GameObject.Find("toolTipText").GetComponent<Text>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            toolTip.text = "Press 'r' to operate record player";
        }

        if (Input.GetKeyDown("r"))
        {
            if (playing)
            {
                recordScript.stopSong();
                lydkilde.Stop();
            }
            else
            {
                recordScript.startSong();
                Invoke("playSound", 3);
            }
            playing = !playing;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            toolTip.text = "";
        }
    }

    private void playSound() {
        lydkilde.Play();
    }
}
