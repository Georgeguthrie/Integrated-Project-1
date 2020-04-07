using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public int shots = 5;
    bool canshoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canshoot)
        {
            Shoot();
            Ammo();
        }
        if (shots <= 0)
        {
            canshoot = false;
            shots = 5;
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(5);
                canshoot = true;
            }
        }
    }

    void Shoot ()
    {
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
    }
    public void Ammo()
    {
        shots -= 1;
    }
}
