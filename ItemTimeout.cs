using UnityEngine;
using System.Collections;

public class ItemTimeout : MonoBehaviour {
    public float minLifetime;
    public float maxLifetime;
    private float lifetime;

	void Start () {
        StartCoroutine(selfDestruct());
	}

    private IEnumerator selfDestruct() {
        lifetime = Random.Range(minLifetime, maxLifetime);
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
