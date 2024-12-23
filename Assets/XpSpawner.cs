using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpSpawner : MonoBehaviour
{
    [SerializeField] GameObject xpPrefab;
    [SerializeField] float spawnTimer = 0.5f;

    [SerializeField] float minTras;
    [SerializeField] float maxTras;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(XpSpawn());
    }

    IEnumerator XpSpawn() {
        while(true){
            var wnated = Random.Range(minTras, maxTras);
            var position = new Vector3(wnated, transform.position.y);
            GameObject gameObject = Instantiate(xpPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
