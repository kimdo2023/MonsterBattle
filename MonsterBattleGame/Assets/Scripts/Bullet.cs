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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Chunk")
        {

            var q = collision.GetComponent<Core>();
            if(q == null)
            {
                collision.GetComponent<ChunkBehaviour>().Destroy();
                Destroy(gameObject);
            }
            else
            {
                if(q.HP == 0)
                {
                    print("?");
                    Destroy(collision);
                    Destroy(gameObject);
                }
            }    

        }
    }
}
