using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWeapon1 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public GameObject bulletprefab2;
    public int shots = 5;
    bool canshoot = true;
    public Shotbar1 Shotbar1;
    public Animator animator;
    public AudioSource Light;
    public AudioSource Heavy;

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && canshoot)
        {
            animator.SetBool("IsPLight", true);
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("IsPLight", false);
            }
            Light.Play();
            Shoot();
            Ammo();
        }
        if (Input.GetButtonDown("Fire3") && canshoot)
        {
            animator.SetBool("IsPHeavy", true);
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("IsPHeavy", false);
            }
            Heavy.Play();
            Shoot2();
            Ammo2();
        }
        if (shots <= 0)
        {
            canshoot = false;
            shots = 5;
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(3);
                canshoot = true;
                Shotbar1.SetShots(shots);
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
    }
    public void Ammo()
    {
        shots -= 1;
        Shotbar1.SetShots(shots);
    }
    void Shoot2()
    {
        Instantiate(bulletprefab2, firePoint.position, firePoint.rotation);
    }
    public void Ammo2()
    {
        shots -= 2;
        Shotbar1.SetShots(shots);
    }

}