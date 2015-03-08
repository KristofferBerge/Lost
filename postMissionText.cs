using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class postMissionText : MonoBehaviour {

	public Text missionText;
	private Animator fadeAnim;

	private string test = "Dette er en liten test for å se hvor fort og hvor langt denne mission.boksen kan skrive. Det skrives en bokstav hvert 0.01-sekund.";

	//printText uses WaitForSeconds and needs to be started as Coroutine
	public void printMissionText(string txt){
		StartCoroutine (printText (txt));
	}

	IEnumerator printText (string txt){
		char[] t = txt.ToCharArray ();
		string toPrint = "";

		//Adds one letter from array, posts text and waits for 0.01s
		for (int i = 0; i < t.Length; i++) {
			toPrint += t[i];
			missionText.text = toPrint;
			yield return new WaitForSeconds(0.01f);
		}
		//Displays complete text for 5s
		yield return new WaitForSeconds (5);
		fadeAnim.SetTrigger ("fadeOut");
		//waits for fade out animation to finish, then empties textboc before alpha is reset by animation.
		yield return new WaitForSeconds(2);
		missionText.text = "";
	}

	
	void Start () {
		fadeAnim = GetComponentInChildren<Animator> ();
		printMissionText (test);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
