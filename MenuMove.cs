using UnityEngine;
using System.Collections;

public class MenuMove : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * 4);
        transform.Translate(Vector3.up * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime/4);
	}
}
