using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform muzzle_L;
    public Transform muzzle_R;
    public GameObject bullet;

    public void ShootFire(bool flipX)
    {

        if(flipX)
        {
            var b = Instantiate(bullet, muzzle_L.position, Quaternion.identity);
            var Bscpt = b.GetComponent<Bullet>();
            Bscpt.LR = false;
        }
        else
        {
            var b = Instantiate(bullet, muzzle_R.position, Quaternion.identity);
            var Bscpt = b.GetComponent<Bullet>();
            Bscpt.LR = true;
        }

    }
}
