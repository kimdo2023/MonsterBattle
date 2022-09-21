using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireSpawner : MonoBehaviour
{

    public GameObject Fire;

    public Vector2 SpawnRange;

    public int FireNumber;

    void Start()
    {
        SpawnFire(FireNumber);
    }

    void Update()
    {
        
    }

    public void SpawnFire(int i)
    {
        for(int j=0 ; j<i ; j++)
        {
            Vector2 SP;
            SP.x = Random.Range(-Mathf.Abs(SpawnRange.x), Mathf.Abs(SpawnRange.x));
            SP.y = Random.Range(-Mathf.Abs(SpawnRange.y), Mathf.Abs(SpawnRange.y));
            Instantiate(Fire, new Vector3(SP.x, SP.y, 0), Quaternion.identity);
        }
    }
}
