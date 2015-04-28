using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
    private GameObject player;
    private playerValues playerVal;
    private VisualizeDamage uiDamage;
    public GameObject bloodSpatter;
    public int damage;
	// Use this for initialization
	void Start () {
        playerVal = GameObject.Find("Persistant").GetComponent<playerValues>();
        destroyBullet(0.5f);
        player = GameObject.Find("UI-script");
        uiDamage = GameObject.Find("DamageOverlay").GetComponent<VisualizeDamage>();
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            //Initiates or increases bleed effect
            playerVal.addDamage(1);
            player.GetComponent<uiUpdate>().setCurrentHealth(10);
            uiDamage.displayDamageOverlay();

        }
        else if (other.gameObject.tag == "enemy") {
            //instantiates particleEmitter on hit position.
            GameObject newSpatter = (GameObject)Instantiate(bloodSpatter, transform.position, transform.rotation);
            //Reduces enemy health
            other.gameObject.GetComponent<EnemyHealth>().reduceHealth(10);
        }
        Destroy(this.gameObject);
    }

    private IEnumerator destroyBullet(float i) {
        yield return new WaitForSeconds(i);
       // Destroy(this.gameObject);
    }
}