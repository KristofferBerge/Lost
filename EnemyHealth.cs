using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int health;

    public void reduceHealth(int delta) {
        health -= delta;
        if (health <= 0) {
            health = 0;
            killEnemy();
        }
        gameObject.GetComponentInChildren<Text>().text = health + "HP";
    }

    private void killEnemy() {
        Debug.Log("ENEMY DEAD");
        Destroy(gameObject);
    }
}
