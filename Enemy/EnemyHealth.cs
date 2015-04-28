using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int health;
    
    //Recieves changes in health points
    public void reduceHealth(int delta) {
        health -= delta;
        //Kills enemy if health is 0 or below
        if (health <= 0) {
            health = 0;
            killEnemy();
        }
        //Displays health points on canvas
        gameObject.GetComponentInChildren<Text>().text = health + "HP";
    }

    //Destroy self when dead
    private void killEnemy() {
        Debug.Log("ENEMY DEAD");
        Destroy(gameObject);
    }
}
