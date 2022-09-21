using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float radius = 1;
    int timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer == 10) {
            timer = 0;
        }   
        if(timer == 2) {
            SpawnObjectAtRandom();
        }
    }
    void SpawnObjectAtRandom() {
        Vector3 randomPos = Random.insideUnitCircle * radius;
        Instantiate(ItemPrefab, randomPos, Quaternion.identity);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
