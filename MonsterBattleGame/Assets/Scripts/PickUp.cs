using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public Shoot shoot;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (itemHolding)
            {
                //itemholding.transform.position = transform.position + direction;
                //itemholding.transform.parent = null;
                //if (itemholding.getcomponent<rigidbody2d>())
                //    itemholding.getcomponent<rigidbody2d>().simulated = true;
                //itemholding = null;
                Destroy(itemHolding);
                bool flipX = GetComponent<SpriteRenderer>().flipX;
                shoot.ShootFire(flipX);
            }
            else
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }

        }
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (itemHolding)
        //    {
        //        StartCoroutine(ThrowItem(itemHolding));
        //        itemHolding = null;
        //    }
        //}
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;
        for (int i = 0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>()) {
            item.GetComponent<Rigidbody2D>().simulated = true;
        }
        Destroy(item);
    }
    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.gameObject.tag == "Chunk") 
    //     {
    //         Destroy(gameObject);
    //     }
    // }

}