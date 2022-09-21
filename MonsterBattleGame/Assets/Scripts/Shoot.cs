using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bullet;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            var b = Instantiate(bullet, muzzle.position, Quaternion.identity);
            var Bscpt = b.GetComponent<Bullet>();
            //if(condition a)
            //    Bscpt.LR = true;
            //else
            //    Bscpt.LR = false;
        }
    }
}
