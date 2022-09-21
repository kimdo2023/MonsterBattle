using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;

    public GameObject LEFT;
    public GameObject RIGHT;

    private void Start() {
        rightAttackOffset = transform.position;
    }

    //public void AttackRight() {
        //swordCollider.enabled = true;
        //transform.localPosition = rightAttackOffset;
    //}

    //public void AttackLeft() {
        //swordCollider.enabled = true;
        //transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    //}

    public void AttackRight()
    {
        swordCollider.enabled = true;
        //transform.localPosition = rightAttackOffset;
        transform.position = RIGHT.transform.position;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        //transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        transform.position = LEFT.transform.position;
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Hello1");
        if (other.gameObject.tag == "Enemy") 
        {
            //Debug.Log("Hello1");
            var scpt = other.gameObject.GetComponentInChildren<Core>();
            if(scpt!=null)
                //Debug.Log("Hello2");
            scpt.LaunchAChunk();
        }
        
    }
}
