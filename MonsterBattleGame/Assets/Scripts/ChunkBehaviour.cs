using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour
{
    //monster body center
    public Transform core;
    public Core Cscpt;
    public Transform anchor;

    //manually set time intervals
    public int counter_KnockedOff_Max;
    public int counter_StayStill_Max;

    //speeds
    public float knockedOffSpeed;
    public float goBackSpeed;
    public float rotationSpeed;

    //real time variables
    float realTimeKnockedOffSpeed;
    int counter_KnockedOff;
    int counter_StayStill;

    //for movements
    Vector2 dir;
    Rigidbody2D rb2D;

    [Header("Debug")]
    //process control
    public bool isAttached;
    public bool isGettingKnockedOff;
    public bool isSlowingDown;
    public bool isStayingStill;
    public bool isGoingBack;

    //for debug
    public float AngularVelocity;

    void Start()
    {
        realTimeKnockedOffSpeed = knockedOffSpeed;

        counter_KnockedOff = counter_KnockedOff_Max;
        counter_StayStill = counter_StayStill_Max;

        rb2D = GetComponent<Rigidbody2D>();
        
        dir = new Vector2(transform.position.x - core.position.x, transform.position.y - core.position.y).normalized;
        
        //set the bools
        isAttached = true;
        isGettingKnockedOff = false;
        isGoingBack = false;
        isSlowingDown = false;
        isStayingStill = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //debug

        if (isGettingKnockedOff)
        {
            LaunchChunk();
        }
        else if(isSlowingDown)
        {
            SlowDown();
        }
        else if(isStayingStill)
        {
            StayStill();
        }
        else if(isGoingBack)
        {
            GoBack();
        }
    }

    //change velocity when hitting borders
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "monsterwall_N"|| collision.gameObject.name == "monsterwall_S")
        { 
            dir.y = -dir.y;
        }
        else if (collision.gameObject.name == "monsterwall_W" || collision.gameObject.name == "monsterwall_E")
        { 
            dir.x = -dir.x;
        }
    }

    void LaunchChunk()
    {
        if(counter_KnockedOff != 0)
        {
            isAttached = false;
            transform.parent = null;
            rb2D.simulated = true;
            counter_KnockedOff--;
            rb2D.velocity = dir * realTimeKnockedOffSpeed;
            //rb2D.AddForce(dir * knockedOffSpeed);
        }
        else
        {
            isGettingKnockedOff = false;
            isSlowingDown = true;
            counter_KnockedOff = counter_KnockedOff_Max;
        }
    }

    void SlowDown()
    {
        if (realTimeKnockedOffSpeed >= 0f)
        {
            realTimeKnockedOffSpeed -= 0.01f;
            rb2D.velocity = dir * realTimeKnockedOffSpeed;
            if (Mathf.Abs(rb2D.angularVelocity) >= 2f)
            {
                if (rb2D.angularVelocity < 0)
                    rb2D.angularVelocity += 2f;
                else if (rb2D.angularVelocity > 0)
                    rb2D.angularVelocity -= 2f;
            }
        }
        else
        {
            isSlowingDown = false;
            isStayingStill = true;
            rb2D.velocity = Vector2.zero;
            rb2D.angularVelocity = 0f;
            realTimeKnockedOffSpeed = knockedOffSpeed;
        }
    }

    void StayStill()
    {
        if (counter_StayStill != 0)
            counter_StayStill--;
        else
        {
            isStayingStill = false;
            isGoingBack = true;
            counter_StayStill = counter_StayStill_Max;
        }
    }

    void GoBack()
    {
        if(Vector2.Distance(new Vector2(anchor.position.x, anchor.position.y), new Vector2(transform.position.x,transform.position.y))>0.2f)
        {
            dir = new Vector2(anchor.position.x - transform.position.x, anchor.position.y - transform.position.y).normalized;
            rb2D.velocity = dir * goBackSpeed;
            //rotate to the direction
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            isGoingBack = false;
            isAttached = true;
            transform.position = anchor.position;
            transform.rotation = anchor.rotation;
            transform.SetParent(anchor, true);
            rb2D.simulated = false;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Cscpt.HP--;
    }
}
