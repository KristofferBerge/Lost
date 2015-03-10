using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {
    
    public int getItemNr(GameObject item){
        string name = item.name;
        int i = 0;
        switch (name)
        {
            case "banana":
                i = 1;
                break;
            case "firstAid":
                i = 2;
                break;
        }
        
        return i;
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
