using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
    private GameObject player;
    private playerValues playerVal;
    public int damage;
	// Use this for initialization
	void Start () {
        playerVal = GameObject.Find("Persistant").GetComponent<playerValues>();
        destroyBullet(0.5f);
        player = GameObject.Find("UI-script");
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            //Initiates or increases bleed effect
            playerVal.addDamage(1);
            player.GetComponent<uiUpdate>().setCurrentHealth(10);
        }
        else if (other.gameObject.tag == "Enemy") { 
        }
        //destroys bullet if it hits target
        Destroy(this.gameObject);
    }

    private IEnumerator destroyBullet(float i) {
        yield return new WaitForSeconds(i);
       // Destroy(this.gameObject);
    }

}
