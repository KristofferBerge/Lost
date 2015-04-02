using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    public Rigidbody bulletPrefab;
    public Transform shotPos;
    public int velocity;

    public void shoot() {
        //Instantiating new bullet and gives it position
        Rigidbody newBullet = (Rigidbody)Instantiate(bulletPrefab, shotPos.position, transform.rotation);
        //Gives bullet force and direction
        newBullet.AddForce(shotPos.up * velocity);
    }
}
