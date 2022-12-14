using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public Vector2 dir;

    public float speed;

    public int counterMax;
    int counter;

    void Start()
    {
        counter = 0;
    }

    void FixedUpdate()
    {
        if(counter == counterMax)
        {
            counter = 0;
            dir.x = Random.Range(-1, 1);
            dir.y = Random.Range(-1, 1);
            dir.Normalize();
        }
        counter++;
        transform.Translate(new Vector3(dir.x,dir.y,0)*speed*Time.deltaTime,Space.World);
    }


}
