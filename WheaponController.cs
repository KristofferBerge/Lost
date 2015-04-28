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
        //Disables wheapon mesh on start
        wheapon.SetActive(false);
	}
    //Displays wheapon
    public void showWheapon(bool show){
        if (show) {
            wheapon.SetActive(true);
        }
        else {
            wheapon.SetActive(false);
        }
    }

    public void fire() {
        //Instanntiates bulletprefab
        Rigidbody newBullet = (Rigidbody)Instantiate(bulletPrefab, shotPos.position, transform.rotation);
        //Gives bullet velocity and direction
        newBullet.AddForce(shotPos.forward * velocity);
        //Play shooting sound
        lydkilde.PlayOneShot(skytelyd);
        //Particlesystem makes muzzleflash
        muzzleFlash.Play();
    }

    void Update() {
        if (wheapon.activeSelf) { 
            if(Input.GetButtonUp("Fire1")){
                //If wheapon is visible: Fire bullet when fire1 button is clicked
                fire();
            }
        }
    }
}
