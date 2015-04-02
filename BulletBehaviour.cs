using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
    private playerValues playerVal;
	// Use this for initialization
	void Start () {
        playerVal = GameObject.Find("Persistant").GetComponent<playerValues>();
        destroyBullet(0.5f);
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            //Initiates or increases bleed effect
            playerVal.addDamage(1);
        }
        else if (other.gameObject.tag == "Enemy") { 
            //Needs enemy health script
        }
        //destroys bullet if it hits target
        Destroy(this.gameObject);
    }

    private IEnumerator destroyBullet(float i) {
        yield return new WaitForSeconds(i);
       // Destroy(this.gameObject);
    }

}
