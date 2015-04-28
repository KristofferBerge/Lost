using UnityEngine;
using System.Collections;

public class RandomDrop : MonoBehaviour {
    public Rigidbody itemPrefab;
    public string prefabName;
    public float minInterval;
    public float maxInterval;
    private float timeout;

    void Start(){
        StartCoroutine(setTimeout());
    }

    private IEnumerator setTimeout() {
        //Eternal loop drops fruit from tree with random intervals between max and min set as public int
        while (true){
            timeout = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(timeout);
            dropItem();
        }
    }

    private void dropItem(){
        //Instantiates prefab set as public rigidbody(fruit)
        Rigidbody newItem = (Rigidbody)Instantiate(itemPrefab, transform.position, transform.rotation);
        newItem.name = prefabName;
    }
}
