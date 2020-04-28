using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public GameObject bulletprefab2;
    public int shots = 5;
    bool canshoot = true;
    public Shotbar2 Shotbar2;
    public Animator animator;
    public AudioSource Light;
    public AudioSource Heavy;

    void Update()
    {

        if (Input.GetButtonDown("Fire2") && canshoot)
        {
            animator.SetBool("IsLight", true);
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("IsLight", false);
            }
            Light.Play();
            Shoot();
            Ammo();
        }
        if (Input.GetButtonDown("Fire4") && canshoot)
        {
            animator.SetBool("Isheavy", true);
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(0.8f);
                animator.SetBool("Isheavy", false);
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
                Shotbar2.SetShots(shots);
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
        Shotbar2.SetShots(shots);
    }
    void Shoot2()
    {
        Instantiate(bulletprefab2, firePoint.position, firePoint.rotation);
    }
    public void Ammo2()
    {
        shots -= 2;
        Shotbar2.SetShots(shots);
    }

}
