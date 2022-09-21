using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2d;
    float speed;
    public bool LR;

    void Start()
    {
        speed = 3f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(LR)
        rb2d.velocity = Vector2.right * speed;
        else
        rb2d.velocity = Vector2.left * speed;
    }
}
