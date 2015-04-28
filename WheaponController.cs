using UnityEngine;
using System.Collections;

public class WheaponController : MonoBehaviour {

    public GameObject wheapon;
    public Rigidbody bulletPrefab;
    public Transform shotPos;
    public int velocity;
    public ParticleSystem muzzleFlash;
    public AudioSource lydkilde;
    public AudioClip skytelyd;
	void Start () {
        wheapon.SetActive(false);
	}

    public void showWheapon(bool show){
        if (show) {
            wheapon.SetActive(true);
        }
        else {
            wheapon.SetActive(false);
        }
    }

    public void fire() {
        Rigidbody newBullet = (Rigidbody)Instantiate(bulletPrefab, shotPos.position, transform.rotation);
        newBullet.AddForce(shotPos.forward * velocity);
        lydkilde.PlayOneShot(skytelyd);
        muzzleFlash.Play();
    }

    void Update() {
        if (wheapon.activeSelf) { 
            if(Input.GetButtonUp("Fire1")){
                fire();
            }
        }
    }
}
