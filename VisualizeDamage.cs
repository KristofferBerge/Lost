using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisualizeDamage : MonoBehaviour {
    private Image damageOverlay;

	void Awake () {
        damageOverlay = gameObject.GetComponent<Image>();
        damageOverlay.CrossFadeAlpha(0,0.1f,false);
	}

    public void displayDamageOverlay(){
        StartCoroutine(fadeOverlay());
    }
    private IEnumerator fadeOverlay() {
        damageOverlay.CrossFadeAlpha(0.5f, 0.01f, false);
        yield return new WaitForSeconds(0.5f);
        damageOverlay.CrossFadeAlpha(0, 1, false);
    }
}
