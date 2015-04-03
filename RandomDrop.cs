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
        while (true){
            timeout = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(timeout);
            dropItem();
        }
    }

    private void dropItem()
    {
        Debug.Log("Dropped Item");
        Rigidbody newItem = (Rigidbody)Instantiate(itemPrefab, transform.position, transform.rotation);
        newItem.name = prefabName;
    }
}
