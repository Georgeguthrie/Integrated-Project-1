﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletp2 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player1 player1 = hitInfo.GetComponent<Player1>();
        if (player1 != null)
        {
            player1.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
