using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class postMissionText : MonoBehaviour {

	public Text missionText;
	public float printSpeed;

	//printText uses WaitForSeconds and needs to be started as Coroutine
	public void printMissionText(string txt){
		StartCoroutine (printText (txt));
	}

	IEnumerator printText (string txt){
		char[] t = txt.ToCharArray ();
		string toPrint = "";

		//Adds one letter from array, posts text and waits
		for (int i = 0; i < t.Length; i++) {
			toPrint += t[i];
			missionText.text = toPrint;
			yield return new WaitForSeconds(printSpeed);
		}
		//Displays complete text for 5s
		yield return new WaitForSeconds (5);
		missionText.CrossFadeAlpha (0, 0.5f, false);
		yield return new WaitForSeconds (2);
		//Empties textbox in canvas before setting alpha back to 1
		missionText.text = "";
		missionText.CrossFadeAlpha (1,1,false);
	}

	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
