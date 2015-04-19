using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {
    public int interval;
    public float intensity;
    private Light redLight;

    void Awake() {
        redLight = GetComponent<Light>();
    }

    public void startBlink() {
        StartCoroutine(lightDimmer());
    }

    private IEnumerator lightDimmer() {
        while (true){
            redLight.intensity = intensity;
            yield return new WaitForSeconds(interval);
            redLight.intensity = 0;
            yield return new WaitForSeconds(interval);
        }
    }
}
