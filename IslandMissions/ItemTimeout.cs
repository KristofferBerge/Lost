using UnityEngine;
using System.Collections;

public class ItemTimeout : MonoBehaviour {
    public float minLifetime;
    public float maxLifetime;
    private float lifetime;

	void Start () {
        StartCoroutine(selfDestruct());
	}
    //Fruit will destroy self after random number of seconds between max and min set as public int
    private IEnumerator selfDestruct() {
        lifetime = Random.Range(minLifetime, maxLifetime);
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
