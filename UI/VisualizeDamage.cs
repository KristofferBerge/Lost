using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisualizeDamage : MonoBehaviour {
    private Image damageOverlay;

	void Awake () {
        //Stores reference and sets alpha to 0 to hide
        damageOverlay = gameObject.GetComponent<Image>();
        damageOverlay.CrossFadeAlpha(0,0.01f,false);
	}

    public void displayDamageOverlay(){
        StartCoroutine(fadeOverlay());
    }
    private IEnumerator fadeOverlay() {
        //Fades in overlay quickly
        damageOverlay.CrossFadeAlpha(0.5f, 0.01f, false);
        //Waits 0.5 second
        yield return new WaitForSeconds(0.5f);
        //Fades out  overlay slowly
        damageOverlay.CrossFadeAlpha(0, 1, false);
    }
}
