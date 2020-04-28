using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bulletp2 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public Sprite Sprite;
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PPlayer1 pplayer1 = hitInfo.GetComponent<PPlayer1>();
        if (pplayer1 != null)
        {
            pplayer1.TakeDamage(damage);
            Destroy(gameObject);
        }
        Player1 player1 = hitInfo.GetComponent<Player1>();
        if (player1 != null)
        {
            player1.TakeDamage(damage);
            Destroy(gameObject);
        }
        YPlayer1 Yplayer1 = hitInfo.GetComponent<YPlayer1>();
        if (Yplayer1 != null)
        {
            Yplayer1.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

